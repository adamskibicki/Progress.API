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
    public class UserCharactersQuery : IRequest<IEnumerable<UserCharacterDto>>
    {
    }

    internal class UserCharactersQueryHandler : IRequestHandler<UserCharactersQuery, IEnumerable<UserCharacterDto>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UserCharactersQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserCharacterDto>> Handle(UserCharactersQuery request, CancellationToken cancellationToken)
        {
            var result = await dbContext.CharacterStatuses
                .Include(cs => cs.UserCharacter)
                .Select(cs => new
                {
                    cs.BasicInformation.Name,
                    cs.BasicInformation.Title,
                    cs.CreatedAt,
                    cs.UserCharacterId,
                    cs.Id
                })
                .ToArrayAsync(cancellationToken);

            return result.GroupBy(x => x.UserCharacterId)
                .Select(x => x.OrderByDescending(y => y.CreatedAt).First())
                .Select(x => new UserCharacterDto
                {
                    LastEdited = x.CreatedAt,
                    Name = x.Name,
                    Title = x.Title,
                    StatusId = x.Id
                });
        }
    }
}
