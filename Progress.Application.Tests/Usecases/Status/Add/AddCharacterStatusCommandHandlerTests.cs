using AutoMapper;
using AutoMapper.Execution;
using FluentValidation;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Tests.Usecases.Common;
using Progress.Application.Usecases.Status.Add;
using Progress.Application.Usecases.Status.Get;
using System;
using Xunit;

namespace Progress.Application.Tests.Usecases.Status.Add
{
    public class AddCharacterStatusCommandHandlerTests : IAsyncLifetime
    {
        private ApplicationDbContext dbContext;
        private IMapper mapper;
        private AddCharacterStatusCommandHandler handler;
        private Guid oldCharacterStatusId;

        public async Task InitializeAsync()
        {
            dbContext = Fixtures.CreateApplicationDbContext();
            await AddOldCharacterStatusIdAsync();
            mapper = Fixtures.CreateMapper();
            var validators = new List<IValidator<AddCharacterStatusCommand>>();
            handler = new AddCharacterStatusCommandHandler(dbContext, mapper, validators);
        }

        private async Task AddOldCharacterStatusIdAsync()
        {
            oldCharacterStatusId = Guid.NewGuid();
            var oldCharacterStatus = new CharacterStatus() { Id = oldCharacterStatusId };
            var userCharacter = new UserCharacter() { Id = Guid.NewGuid(), CharacterStatuses = new List<CharacterStatus>() { oldCharacterStatus } };
            dbContext.UserCharacters.Add(userCharacter);
            await dbContext.SaveChangesAsync();
        }

        public Task DisposeAsync()
        {
            dbContext.Dispose();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task AddsNewCharacterStatus()
        {
            // Arrange
            var command = new AddCharacterStatusCommand
            {
                CharacterStatusId = oldCharacterStatusId,
                CharacterStatus = new CharacterStatusRequestDto()
                {
                    GeneralInformation = new GeneralInformationRequestDto()
                    {
                        Resources = Array.Empty<ResourceRequestDto>(),
                        Stats = new StatsRequestDto(Array.Empty<StatRequestDto>(), 0)
                    }
                }
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsRight);

            StatusDto resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.SingleOrDefault(cs => cs.Id == resultDto.Id);
            Assert.NotNull(addedStatus);
        }

        [Fact]
        public async Task AddsResourcesAndStatsToDb()
        {
            // Arrange
            var command = new AddCharacterStatusCommand
            {
                CharacterStatusId = oldCharacterStatusId,
                CharacterStatus = new CharacterStatusRequestDto()
                {
                    GeneralInformation = new GeneralInformationRequestDto()
                    {
                        Resources = new[]
                        {
                            new ResourceRequestDto(null, string.Empty, 0),
                            new ResourceRequestDto(null, string.Empty, 0)
                        },
                        Stats = new StatsRequestDto(new[]
                        {
                            new StatRequestDto(null, string.Empty, 5, false),
                            new StatRequestDto(null, string.Empty, 5, false)
                        }
                        , 1)
                    },
                }
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsRight);

            StatusDto resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.SingleOrDefault(cs => cs.Id == resultDto.Id);

            Assert.Equal(2, dbContext.Stats.Count());
            Assert.Equal(2, dbContext.Resources.Count());
            Assert.Equal(2, addedStatus.Stats.Count);
            Assert.Equal(2, addedStatus.Resources.Count);

            Assert.Empty(addedStatus.Resources.Where(r => r.BaseStat is not null || r.BaseStatId is not null));
        }

        [Fact]
        public async Task ResourcesAndStatsHaveRelationInDbBasedOnBaseStatId()
        {
            // Arrange
            var stat0Id = Guid.NewGuid();
            var stat1Id = Guid.NewGuid();
            var command = new AddCharacterStatusCommand
            {
                CharacterStatusId = oldCharacterStatusId,
                CharacterStatus = new CharacterStatusRequestDto()
                {
                    GeneralInformation = new GeneralInformationRequestDto()
                    {
                        Resources = new[]
                        {
                            new ResourceRequestDto(stat0Id, string.Empty, 0),
                            new ResourceRequestDto(stat1Id, string.Empty, 0)
                        },
                        Stats = new StatsRequestDto(new[]
                        {
                            new StatRequestDto(stat0Id, string.Empty, 5, false),
                            new StatRequestDto(stat1Id, string.Empty, 5, false)
                        }
                        , 1)
                    },
                }
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsRight);

            StatusDto resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.SingleOrDefault(cs => cs.Id == resultDto.Id);

            Assert.Equal(2, dbContext.Stats.Count());
            Assert.Equal(2, dbContext.Resources.Count());
            Assert.Equal(2, addedStatus.Stats.Count);
            Assert.Equal(2, addedStatus.Resources.Count);

            Assert.Equal(addedStatus.Resources[0].BaseStat.Id, addedStatus.Stats[0].Id);
            Assert.Equal(addedStatus.Resources[1].BaseStat.Id, addedStatus.Stats[1].Id);
        }

        [Fact]
        public async Task AddsSkillsWithRelatedDataToDb()
        {
            // Arrange
            var command = new AddCharacterStatusCommand
            {
                CharacterStatusId = oldCharacterStatusId,
                CharacterStatus = new CharacterStatusRequestDto()
                {
                    GeneralInformation = new GeneralInformationRequestDto()
                    {
                        Resources = Array.Empty<ResourceRequestDto>(),
                        Stats = new StatsRequestDto(Array.Empty<StatRequestDto>(), 1)
                    },
                    Classes = new[]
                    {
                        new CharacterClassRequestDto()
                        {
                            Level = 1,
                            Modifiers = Array.Empty<ClassModifierRequestDto>(),
                            Name = "Test",
                            Skills = new[]
                            {
                                new SkillRequestDto()
                                {
                                    Name = string.Empty,
                                    Level = 1,
                                    Tier = 1,
                                    Type = SkillType.Active,
                                    Enhanced = true,
                                    TierDescriptions = new[]
                                    {
                                        new TierDescriptionRequestDto(string.Empty, 1),
                                        new TierDescriptionRequestDto(string.Empty, 1),
                                    },
                                    CategoryIds = Array.Empty<Guid>(),
                                    Variables = Array.Empty<SkillVariableRequestDto>()
                                },
                                new SkillRequestDto()
                                {
                                    Name = string.Empty,
                                    Level = 1,
                                    Tier = 1,
                                    Type = SkillType.Active,
                                    Enhanced = true,
                                    TierDescriptions = new[]
                                    {
                                        new TierDescriptionRequestDto(string.Empty, 1),
                                        new TierDescriptionRequestDto(string.Empty, 1),
                                    },
                                    CategoryIds = Array.Empty<Guid>(),
                                    Variables = Array.Empty<SkillVariableRequestDto>()
                                }
                            }
                        }
                    }
                }
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsRight);

            StatusDto resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.SingleOrDefault(cs => cs.Id == resultDto.Id);

            Assert.Equal(2, dbContext.Skills.Count());
            Assert.Equal(2, addedStatus.CharacterClasses.Single().Skills.Count);
            Assert.Equal(4, dbContext.TierDescriptions.Count());
            Assert.Equal(2, addedStatus.CharacterClasses.Single().Skills[0].TierDescriptions.Count);
            Assert.Equal(2, addedStatus.CharacterClasses.Single().Skills[1].TierDescriptions.Count);
        }

        [Fact]
        public async Task AddsClassesToDb()
        {
            // Arrange
            var command = new AddCharacterStatusCommand
            {
                CharacterStatusId = oldCharacterStatusId,
                CharacterStatus = new CharacterStatusRequestDto()
                {
                    GeneralInformation = new GeneralInformationRequestDto()
                    {
                        Resources = Array.Empty<ResourceRequestDto>(),
                        Stats = new StatsRequestDto(Array.Empty<StatRequestDto>(), 1)
                    },
                    Classes = new[]
                    {
                        new CharacterClassRequestDto()
                        {
                            Level = 1,
                            Modifiers = Array.Empty<ClassModifierRequestDto>(),
                            Name = "Test",
                            Skills = Array.Empty<SkillRequestDto>()
                        },
                        new CharacterClassRequestDto()
                        {
                            Level = 1,
                            Modifiers = Array.Empty<ClassModifierRequestDto>(),
                            Name = "Test",
                            Skills = Array.Empty<SkillRequestDto>()
                        }
                    }
                }
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsRight);

            StatusDto resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.SingleOrDefault(cs => cs.Id == resultDto.Id);

            Assert.Equal(2, dbContext.CharacterClasses.Count());
            Assert.Equal(2, addedStatus.CharacterClasses.Count);
        }

        [Fact]
        public async Task AddsSkillsWithSkillVariablesToDb()
        {
            // Arrange
            var command = new AddCharacterStatusCommand
            {
                CharacterStatusId = oldCharacterStatusId,
                CharacterStatus = new CharacterStatusRequestDto()
                {
                    GeneralInformation = new GeneralInformationRequestDto()
                    {
                        Resources = Array.Empty<ResourceRequestDto>(),
                        Stats = new StatsRequestDto(Array.Empty<StatRequestDto>(), 1)
                    },
                    Classes = new[]
                    {
                        new CharacterClassRequestDto()
                        {
                            Level = 1,
                            Modifiers = Array.Empty<ClassModifierRequestDto>(),
                            Name = "Test",
                            Skills = new[]
                            {
                                new SkillRequestDto()
                                {
                                    Name = string.Empty,
                                    Level = 1,
                                    Tier = 1,
                                    Type = SkillType.Active,
                                    Enhanced = true,
                                    TierDescriptions = Array.Empty<TierDescriptionRequestDto>(),
                                    CategoryIds = Array.Empty<Guid>(),
                                    Variables = new[]
                                    {

                                        new SkillVariableRequestDto(),
                                        new SkillVariableRequestDto(),
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsRight);

            StatusDto resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.SingleOrDefault(cs => cs.Id == resultDto.Id);

            Assert.Equal(2, dbContext.Skills.Count());
            Assert.Equal(2, addedStatus.CharacterClasses.Single().Skills.Count);
            Assert.Equal(4, dbContext.TierDescriptions.Count());
            Assert.Equal(2, addedStatus.CharacterClasses.Single().Skills[0].TierDescriptions.Count);
            Assert.Equal(2, addedStatus.CharacterClasses.Single().Skills[1].TierDescriptions.Count);
        }

        //TODO: add tests for checking adding skill categories and skill variables
    }
}
