using AutoMapper;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Categories;
using Progress.Application.Usecases.Status;
using Progress.Application.Usecases.UserCharacters;

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
            CreateMap<CharacterStatus, UserCharacterDto>()
                .ForMember(ucd => ucd.LastEdited, o => o.MapFrom(cs => cs.CreatedAt))
                .ForMember(ucd => ucd.Name, o => o.MapFrom(cs => cs.BasicInformation.Name))
                .ForMember(ucd => ucd.Title, o => o.MapFrom(cs => cs.BasicInformation.Title))
                .ForMember(ucd => ucd.StatusId, o => o.MapFrom(cs => cs.Id))
                .ForMember(ucd => ucd.Id, o => o.MapFrom(cs => cs.UserCharacterId));
        }
    }
}
