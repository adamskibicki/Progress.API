using FluentValidation;
using Progress.Application.Persistence.Entities;
using Progress.Application.Persistence;
using Progress.Application.Usecases.Status.Delete;
using Progress.Application.Tests.Usecases.Common;

namespace Progress.Application.Tests.Usecases.Status.Delete
{
    public class DeleteCharacterStatusCommandHandlerTests
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DeleteCharacterStatusCommandHandler handler;

        public DeleteCharacterStatusCommandHandlerTests()
        {
            dbContext = TestHelpersFactory.CreateApplicationDbContext();
            handler = new DeleteCharacterStatusCommandHandler(dbContext,
                new List<IValidator<DeleteCharacterStatusCommand>>());
        }

        [Fact]
        public async Task Handle_ShouldDeleteCharacterStatus_WhenIdIsProvidedAndExistsOtherCharacterStatusWithinSameUserCharacter()
        {
            // Arrange
            var existingStatusId = Guid.NewGuid();
            var userCharacter = await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(existingStatusId);
            await dbContext.AddNewCharacterStatusToUserCharacter(userCharacter, Guid.NewGuid());

            var command = new DeleteCharacterStatusCommand { Id = existingStatusId };
            
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsRight);
        }

        [Fact]
        public async Task Handle_ShouldThrowError_WhenDeletingLastStatusForUserCharacter()
        {
            // Arrange
            var existingStatusId = Guid.NewGuid();
            await dbContext.CreateUserCharacterWithCharacterStatusThatHaveProvidedId(existingStatusId);
            var command = new DeleteCharacterStatusCommand { Id = existingStatusId };

            // Act

            // Assert
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}