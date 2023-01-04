using AutoMapper;
using Progress.Application.Quests.GetAllQuests;
using Progress.Domain.Entities;

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
