using AutoMapper;
using MediatR;

namespace Progress.Application.Quests.GetAllQuests
{
    public class GetAllQuestsQuery: IRequest<IEnumerable<QuestDto>>
    {
        public Guid TreeId { get; set; }
    }

    public class GetAllQuestsQueryHandler : IRequestHandler<GetAllQuestsQuery, IEnumerable<QuestDto>>
    {
        private readonly IQuestRepository questRepository;
        private readonly IMapper mapper;

        public GetAllQuestsQueryHandler(IQuestRepository questRepository, IMapper mapper)
        {
            this.questRepository = questRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<QuestDto>> Handle(GetAllQuestsQuery request, CancellationToken cancellationToken)
        {
            var quests = await questRepository.GetAllAsync(request.TreeId);

            return mapper.Map<QuestDto[]>(quests);
        }
    }
}
