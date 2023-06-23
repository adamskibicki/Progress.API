using FluentValidation;
using LanguageExt;
using MediatR;
using Progress.Application.Common;
using Progress.Application.Persistence;

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
            var entityToRemove = dbContext.CharacterStatuses.Single(uc => uc.Id == request.Id);

            dbContext.CharacterStatuses.Remove(entityToRemove);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
