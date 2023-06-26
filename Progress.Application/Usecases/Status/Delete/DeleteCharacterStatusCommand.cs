using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;

namespace Progress.Application.Usecases.Status.Delete
{
    using Unit = MediatR.Unit;

    public class DeleteCharacterStatusCommand : IRequest<Either<Failure, Unit>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCharacterStatusCommandHandler : ValidationRequestHandler<DeleteCharacterStatusCommand, Unit>
    {
        private readonly ApplicationDbContext dbContext;

        public DeleteCharacterStatusCommandHandler(ApplicationDbContext dbContext, IEnumerable<IValidator<DeleteCharacterStatusCommand>> validators) : base(validators)
        {
            this.dbContext = dbContext;
        }

        protected override async Task<Either<Failure, Unit>> WrappedHandle(DeleteCharacterStatusCommand request, CancellationToken cancellationToken)
        {
            var entityToRemove = dbContext.CharacterStatuses
                .Include(cs => cs.UserCharacter)
                .Single(cs => cs.Id == request.Id);

            CheckIfUserCharacterHaveMoreThanOneCharacterStatus(entityToRemove);

            dbContext.CharacterStatuses.Remove(entityToRemove);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void CheckIfUserCharacterHaveMoreThanOneCharacterStatus(CharacterStatus entityToRemove)
        {
            if (entityToRemove.UserCharacter.CharacterStatuses.Count() == 1)
            {
                throw new Exception($"Cannot delete last {nameof(CharacterStatus)} from {nameof(UserCharacter)}");
            }
        }
    }
}
