using AutoMapper;
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
        private ApplicationDbContext dbContext;
        private IMapper mapper;
        private AddCharacterStatusCommandHandler handler;

        public AddCharacterStatusCommandHandlerTests()
        {
            dbContext = Fixtures.CreateApplicationDbContext();
            mapper = Fixtures.CreateMapper();
            var validators = new List<IValidator<AddCharacterStatusCommand>>();
            handler = new AddCharacterStatusCommandHandler(dbContext, mapper, validators);
        }

        [Fact]
        public async Task Handle_ValidCommand_AddsNewCharacterStatus()
        {
            // Arrange
            var oldCharacterStatusId = Guid.NewGuid();
            var oldCharacterStatus = new CharacterStatus() { Id = oldCharacterStatusId };
            var userCharacter = new UserCharacter() { Id = Guid.NewGuid(), CharacterStatuses = new List<CharacterStatus>() { oldCharacterStatus } };
            dbContext.UserCharacters.Add(userCharacter);
            await dbContext.SaveChangesAsync();

            var command = new AddCharacterStatusCommand
            {
                CharacterStatusId = oldCharacterStatusId,
                CharacterStatus = new CharacterStatusRequestDto()
                {
                    GeneralInformation = new GeneralInformationRequestDto()
                    {
                        Resources = new[]
                        {
                            new ResoureRequestDto(null, string.Empty, 0),
                            new ResoureRequestDto(null, string.Empty, 0)
                        },
                        Stats = new StatsRequestDto(new[]
                        { 
                            new StatRequestDto(string.Empty, 5, false), 
                            new StatRequestDto(string.Empty, 5, false) 
                        }
                        , 1)
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

            Assert.Equal(2, addedStatus.Resources.Count);
            Assert.Equal(2, dbContext.Resources.Count());
            Assert.Equal(2, addedStatus.Stats.Count);
            Assert.Equal(2, dbContext.Stats.Count());
            Assert.Equal(1, addedStatus.UnspentStatpoints);
        }
    }
}
