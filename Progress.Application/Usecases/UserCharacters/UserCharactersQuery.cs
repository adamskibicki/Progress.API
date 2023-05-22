using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.UserCharacters
{
    public class UserCharactersQuery : IRequest<IEnumerable<UserCharacterResponseDto>>
    {
    }

    internal class UserCharactersQueryHandler : IRequestHandler<UserCharactersQuery, IEnumerable<UserCharacterResponseDto>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UserCharactersQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserCharacterResponseDto>> Handle(UserCharactersQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.UserCharacters
                .Include(uc => uc.CharacterStatuses)
                .ProjectTo<UserCharacterResponseDto>(mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
