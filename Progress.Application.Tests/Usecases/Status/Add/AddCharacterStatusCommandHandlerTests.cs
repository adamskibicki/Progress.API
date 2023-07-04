using AutoFixture;
using FluentValidation;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Tests.Usecases.Common;
using Progress.Application.Usecases.Status.Add;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Tests.Usecases.Status.Add
{
    public class AddCharacterStatusCommandHandlerTests
    {
        private readonly ApplicationDbContext dbContext;
        private readonly AddCharacterStatusCommandHandler handler;
        private readonly Fixture fixture;

        public AddCharacterStatusCommandHandlerTests()
        {
            fixture = new Fixture();
            dbContext = TestHelpersFactory.CreateApplicationDbContext();
            var mapper = TestHelpersFactory.CreateMapper();
            handler = new AddCharacterStatusCommandHandler(dbContext, mapper,
                new List<IValidator<AddCharacterStatusCommand>>());
        }

        [Fact]
        public async Task Handle_ShouldAddNewCharacterStatus_WhenCommandIsProvided()
        {
            // Arrange
            var oldCharacterStatusId = Guid.NewGuid();
            await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(oldCharacterStatusId);
            var command = fixture.Build<AddCharacterStatusCommand>()
                .With(x => x.CharacterStatusId, oldCharacterStatusId)
                .Create();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsRight.Should().BeTrue();

            var resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.SingleOrDefault(cs => cs.Id == resultDto.Id);

            addedStatus.Should().NotBeNull();
        }

        [Fact]
        public async Task Handle_ShouldAddResourcesAndStatsToDb_WhenCommandIsProvided()
        {
            // Arrange
            var oldCharacterStatusId = Guid.NewGuid();
            await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(oldCharacterStatusId);
            var command = fixture.Build<AddCharacterStatusCommand>()
                .With(c => c.CharacterStatusId, oldCharacterStatusId)
                .With(c => c.CharacterStatus, fixture.Build<CharacterStatusRequestDto>()
                    .With(cs => cs.GeneralInformation, fixture.Build<GeneralInformationRequestDto>()
                        .With(gi => gi.Resources, new[]
                        {
                            new ResourceRequestDto(null, string.Empty, 0),
                            new ResourceRequestDto(null, string.Empty, 0)
                        })
                        .With(gi => gi.Stats, fixture.Build<StatsRequestDto>()
                            .With(s => s.Stats, new[]
                            {
                                new StatRequestDto(null, string.Empty, 5, false),
                                new StatRequestDto(null, string.Empty, 5, false)
                            })
                            .Create())
                        .Create())
                    .Create())
                .Create();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsRight.Should().BeTrue();

            var resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.Single(cs => cs.Id == resultDto.Id);

            dbContext.Stats.Count().Should().Be(2);
            dbContext.Resources.Count().Should().Be(2);
            addedStatus.Stats.Count.Should().Be(2);
            addedStatus.Resources.Count.Should().Be(2);

            addedStatus.Resources.Where(r => r.BaseStat is not null || r.BaseStatId is not null).Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_ShouldCreateResourcesAndStatsRelationBasedOnBaseStatId_WhenCommandIsProvided()
        {
            // Arrange
            var stat0Id = Guid.NewGuid();
            var stat1Id = Guid.NewGuid();
            var oldCharacterStatusId = Guid.NewGuid();
            await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(oldCharacterStatusId);
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
            result.IsRight.Should().BeTrue();

            var resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.Single(cs => cs.Id == resultDto.Id);

            dbContext.Stats.Count().Should().Be(2);
            dbContext.Resources.Count().Should().Be(2);
            addedStatus.Stats.Count.Should().Be(2);
            addedStatus.Resources.Count.Should().Be(2);

            addedStatus.Stats[0].Id.Should().Be(addedStatus.Resources[0].BaseStat.Id);
            addedStatus.Stats[1].Id.Should().Be(addedStatus.Resources[1].BaseStat.Id);
        }

        [Fact]
        public async Task Handle_ShouldAddSkillsWithRelatedData_WhenCommandIsProvided()
        {
            // Arrange
            var oldCharacterStatusId = Guid.NewGuid();
            await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(oldCharacterStatusId);
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
            result.IsRight.Should().BeTrue();

            var resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.Single(cs => cs.Id == resultDto.Id);

            dbContext.Skills.Count().Should().Be(2);
            addedStatus.CharacterClasses.Single().Skills.Count.Should().Be(2);
            dbContext.TierDescriptions.Count().Should().Be(4);
            addedStatus.CharacterClasses.Single().Skills[0].TierDescriptions.Count.Should().Be(2);
            addedStatus.CharacterClasses.Single().Skills[1].TierDescriptions.Count.Should().Be(2);
        }

        [Fact]
        public async Task Handle_ShouldAddClasses_WhenCommandIsProvided()
        {
            // Arrange
            var oldCharacterStatusId = Guid.NewGuid();
            await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(oldCharacterStatusId);
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
            result.IsRight.Should().BeTrue();

            var resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.Single(cs => cs.Id == resultDto.Id);

            dbContext.CharacterClasses.Count().Should().Be(2);
            addedStatus.CharacterClasses.Count.Should().Be(2);
        }

        [Fact]
        public async Task Handle_ShouldAddSkillsWithSkillVariables_WhenCommandIsProvided()
        {
            // Arrange
            var oldCharacterStatusId = Guid.NewGuid();
            await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(oldCharacterStatusId);
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
                                        fixture.Create<SkillVariableRequestDto>(),
                                        fixture.Create<SkillVariableRequestDto>()
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
            result.IsRight.Should().BeTrue();

            var resultDto = (StatusDto)result;
            var addedStatus = dbContext.CharacterStatuses.Single(cs => cs.Id == resultDto.Id);
            dbContext.Skills.Single().Variables.Count().Should().Be(2);
            addedStatus.CharacterClasses.Single().Skills.Single().Variables.Count.Should().Be(2);
        }

        //TODO: add tests for checking adding skill categories and skill variables
    }
}