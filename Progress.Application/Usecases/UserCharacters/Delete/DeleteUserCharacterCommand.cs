using FluentValidation;
using LanguageExt;
using MediatR;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Security.Services;

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
        private readonly ICurrentUser currentUser;

        public DeleteUserCharacterCommandHandler(ApplicationDbContext dbContext, ICurrentUser currentUser,
            IEnumerable<IValidator<DeleteUserCharacterCommand>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.currentUser = currentUser;
        }


        protected override async Task<Either<Failure, Unit>> WrappedHandle(DeleteUserCharacterCommand request,
            CancellationToken cancellationToken)
        {
            var entityToRemove = dbContext.UserCharacters.SingleOrDefault(uc => uc.Id == request.Id && uc.UserId == currentUser.Id);

            if (entityToRemove is null)
            {
                return new Failure(new Exception("Error when trying to delete specified user character"));
            }
            
            dbContext.UserCharacters.Remove(entityToRemove);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}