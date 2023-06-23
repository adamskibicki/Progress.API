using FluentValidation;
using Progress.Application.Persistence.Entities;
using Progress.Application.Persistence;
using Progress.Application.Usecases.Status.Delete;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Tests.Usecases.Common;

namespace Progress.Application.Tests.Usecases.Status.Delete
{
    public class DeleteCharacterStatusCommandHandlerTests
    {
        private ApplicationDbContext dbContext;
        private DeleteCharacterStatusCommandHandler handler;

        public DeleteCharacterStatusCommandHandlerTests()
        {
            dbContext = Fixtures.CreateApplicationDbContext();
            handler = new DeleteCharacterStatusCommandHandler(dbContext, new List<IValidator<DeleteCharacterStatusCommand>>());
        }

        [Fact]
        public async Task Handle_ValidCommand_DeletesCharacterStatus()
        {
            var existingStatus = new CharacterStatus { Id = Guid.NewGuid() };
            dbContext.Add(existingStatus);
            await dbContext.SaveChangesAsync();

            var command = new DeleteCharacterStatusCommand { Id = existingStatus.Id };

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsRight);
        }
    }
}
