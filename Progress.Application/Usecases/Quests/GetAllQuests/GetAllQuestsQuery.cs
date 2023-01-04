using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence;

namespace Progress.Application.Usecases.Quests.GetAllQuests
{
    public class GetAllQuestsQuery : IRequest<IEnumerable<QuestDto>>
    {
        public Guid TreeId { get; set; }
    }

    public class GetAllQuestsQueryHandler : IRequestHandler<GetAllQuestsQuery, IEnumerable<QuestDto>>
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public GetAllQuestsQueryHandler(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<QuestDto>> Handle(GetAllQuestsQuery request, CancellationToken cancellationToken)
        {
            var quests = await dbContext
                .Quests
                .Where(t => t.Tree.Id == request.TreeId)
                .ProjectTo<QuestDto>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            return mapper.Map<QuestDto[]>(quests);
        }
    }
}
