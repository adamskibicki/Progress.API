using AutoMapper;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Quests.GetAllQuests;

namespace Progress.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Quest, QuestDto>();
        }
    }
}
