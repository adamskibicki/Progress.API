using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Common;
using Progress.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.UserCharacters.Get
{
    public class UserCharactersQuery : IRequest<Either<Failure, IEnumerable<UserCharacterResponseDto>>>
    {
    }

    internal class UserCharactersQueryHandler : ValidationRequestHandler<UserCharactersQuery, IEnumerable<UserCharacterResponseDto>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UserCharactersQueryHandler(ApplicationDbContext dbContext, IMapper mapper, IEnumerable<IValidator<UserCharactersQuery>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task<Either<Failure, IEnumerable<UserCharacterResponseDto>>> WrappedHandle(UserCharactersQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.UserCharacters
                .Include(uc => uc.CharacterStatuses)
                .ProjectTo<UserCharacterResponseDto>(mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
