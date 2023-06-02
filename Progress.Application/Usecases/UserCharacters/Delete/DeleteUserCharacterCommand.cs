using FluentValidation;
using LanguageExt;
using MediatR;
using Progress.Application.Common;
using Progress.Application.Persistence;

namespace Progress.Application.Usecases.UserCharacters.Delete
{
    using Unit = MediatR.Unit;

    public class DeleteUserCharacterCommand : IRequest<Either<Failure, Unit>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserCharacterCommandHandler : ValidationRequestHandler<DeleteUserCharacterCommand, Unit>
    {
        private readonly ApplicationDbContext dbContext;

        public DeleteUserCharacterCommandHandler(ApplicationDbContext dbContext, IEnumerable<IValidator<DeleteUserCharacterCommand>> validators) : base(validators)
        {
            this.dbContext = dbContext;
        }


        protected override async Task<Either<Failure, Unit>> WrappedHandle(DeleteUserCharacterCommand request, CancellationToken cancellationToken)
        {
            var entityToRemove = dbContext.UserCharacters.Single(uc => uc.Id == request.Id);

            dbContext.UserCharacters.Remove(entityToRemove);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
