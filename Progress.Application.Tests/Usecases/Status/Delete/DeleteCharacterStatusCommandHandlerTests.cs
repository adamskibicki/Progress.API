using FluentValidation;
using Progress.Application.Persistence.Entities;
using Progress.Application.Persistence;
using Progress.Application.Usecases.Status.Delete;
using Progress.Application.Tests.Usecases.Common;
using Xunit;

namespace Progress.Application.Tests.Usecases.Status.Delete
{
    public class DeleteCharacterStatusCommandHandlerTests : IAsyncLifetime
    {
        private ApplicationDbContext dbContext;
        private DeleteCharacterStatusCommandHandler handler;
        private CharacterStatus existingStatus;
        private UserCharacter userCharacter;

        public DeleteCharacterStatusCommandHandlerTests()
        {
            dbContext = Fixtures.CreateApplicationDbContext();
            handler = new DeleteCharacterStatusCommandHandler(dbContext, new List<IValidator<DeleteCharacterStatusCommand>>());
        }

        public Task DisposeAsync()
        {
            dbContext.Dispose();
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            userCharacter = new UserCharacter { Id = Guid.NewGuid() };
            existingStatus = new CharacterStatus { Id = Guid.NewGuid() };
            existingStatus.UserCharacter = userCharacter;
            dbContext.Add(existingStatus);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task DeletesCharacterStatus()
        {
            var command = new DeleteCharacterStatusCommand { Id = existingStatus.Id };
            dbContext.CharacterStatuses.Add(new CharacterStatus { UserCharacter = userCharacter });
            await dbContext.SaveChangesAsync();

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsRight);
        }

        [Fact]
        public async Task ThrowsErrorWhenDeletingLastStatusForUserCharacter()
        {
            var command = new DeleteCharacterStatusCommand { Id = existingStatus.Id };

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}
