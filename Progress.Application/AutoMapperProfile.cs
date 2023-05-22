using AutoMapper;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Categories;
using Progress.Application.Usecases.Status.Add;
using Progress.Application.Usecases.Status.Get;
using Progress.Application.Usecases.UserCharacters;

namespace Progress.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<AddNewCategoryCommand, Category>()
                .ForMember(c => c.Id, o => o.Ignore())
                .ForMember(c => c.Skills, o => o.Ignore());
            CreateMap<Resource, ResourceDto>();
            CreateMap<BasicInformation, BasicInformationDto>();
            CreateMap<Stat, StatDto>();
            CreateMap<UnspentSkillpoints, UnspentSkillpointsDto>();
            CreateMap<CharacterClass, ClassDto>()
                .ForMember(c => c.Modifiers, o => o.MapFrom(c => c.ClassModifiers));
            CreateMap<ClassModifier, ClassModifierDto>();
            CreateMap<UserCharacter, UserCharacterResponseDto>();
            CreateMap<CharacterStatus, CharacterStatusSimplifiedResponseDto>()
                .ForMember(dto => dto.Name, o => o.MapFrom(cs => cs.BasicInformation.Name))
                .ForMember(dto => dto.Title, o => o.MapFrom(cs => cs.BasicInformation.Title));

            CreateMap<Skill, SkillDto>();
            CreateMap<TierDescription, TierDescriptionDto>();
            CreateMap<SkillVariable, SkillVariableDto>()
                .ForMember(svd => svd.AffectedStatIds, o => o.MapFrom(sv => sv.AffectedStats.Select(a => a.StatId)));
            CreateMap<CharacterStatus, StatusDto>()
                .ForPath(sd => sd.GeneralInformation.BasicInfo, o => o.MapFrom(cs => cs.BasicInformation))
                .ForPath(sd => sd.GeneralInformation.Resources, o => o.MapFrom(cs => cs.Resources))
                .ForPath(sd => sd.GeneralInformation.Skillpoints, o => o.MapFrom(cs => cs.UnspentSkillpoints))
                .ForPath(sd => sd.GeneralInformation.Stats.UnspentStatpoints, o => o.MapFrom(cs => cs.UnspentStatpoints))
                .ForPath(sd => sd.GeneralInformation.Stats.Stats, o => o.MapFrom(cs => cs.Stats))
                .ForMember(sd => sd.Classes, o => o.MapFrom(cs => cs.CharacterClasses))
                .ForMember(sd => sd.GeneralSkills, o => o.Ignore());

            CreateMap<CharacterStatusRequestDto, CharacterStatus>()
                .ForMember(cs => cs.BasicInformation, o => o.MapFrom(csrd => csrd.GeneralInformation.BasicInfo));
            CreateMap<BasicInfoRequestDto, BasicInformation>();
        }
    }
}
