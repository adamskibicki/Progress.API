using MediatR;
using Progress.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.UserCharacters.Delete
{
    public class DeleteUserCharacterCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserCharacterCommandHandler : IRequestHandler<DeleteUserCharacterCommand>
    {
        private readonly ApplicationDbContext dbContext;

        public DeleteUserCharacterCommandHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserCharacterCommand request, CancellationToken cancellationToken)
        {
            var entityToRemove = dbContext.UserCharacters.Single(uc => uc.Id == request.Id);

            dbContext.UserCharacters.Remove(entityToRemove);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
