using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Security.Services;

namespace Progress.Application.Usecases.UserCharacters.Get
{
    public record GetUserCharactersQuery : IRequest<Either<Failure, IEnumerable<UserCharacterResponseDto>>>;

    public class GetUserCharactersQueryHandler : ValidationRequestHandler<GetUserCharactersQuery, IEnumerable<UserCharacterResponseDto>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;

        public GetUserCharactersQueryHandler(ApplicationDbContext dbContext, IMapper mapper, ICurrentUser currentUser,
            IEnumerable<IValidator<GetUserCharactersQuery>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.currentUser = currentUser;
        }

        protected override async Task<Either<Failure, IEnumerable<UserCharacterResponseDto>>> WrappedHandle(GetUserCharactersQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.UserCharacters
                .Where(uc => uc.UserId == currentUser.Id)
                .Include(uc => uc.CharacterStatuses)
                .ProjectTo<UserCharacterResponseDto>(mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
