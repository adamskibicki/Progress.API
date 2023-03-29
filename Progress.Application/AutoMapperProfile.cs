using AutoMapper;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Categories;
using Progress.Application.Usecases.Status;

namespace Progress.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<AddNewCategoryCommand, Category>()
                .ForMember(c => c.Id, o => o.Ignore());
            CreateMap<Resource, ResourceDto>();
            CreateMap<BasicInformation, BasicInformationDto>();
            CreateMap<Stat, StatDto>();
            CreateMap<UnspentSkillpoints, UnspentSkillpointsDto>();
            CreateMap<CharacterClass, ClassDto>()
                .ForMember(c => c.Modifiers, o => o.MapFrom(c => c.ClassModifiers));
            CreateMap<ClassModifier, ClassModifierDto>();
        }
    }
}
