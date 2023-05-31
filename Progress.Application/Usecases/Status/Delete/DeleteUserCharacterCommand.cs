using MediatR;
using Progress.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.Status.Delete
{
    public class DeleteCharacterStatusCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteCharacterStatusCommandHandler : IRequestHandler<DeleteCharacterStatusCommand>
    {
        private readonly ApplicationDbContext dbContext;

        public DeleteCharacterStatusCommandHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCharacterStatusCommand request, CancellationToken cancellationToken)
        {
            var entityToRemove = dbContext.CharacterStatuses.Single(uc => uc.Id == request.Id);

            dbContext.CharacterStatuses.Remove(entityToRemove);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
