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
            CreateMap<Guid?, Guid>().ConvertUsing((s, _) => throw new Exception("Cannot convert from nullable Guid to Guid"));

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
            CreateMap<ClassModifier, ClassModifierResponseDto>()
                .ForMember(cmd => cmd.CategoryId, o => o.MapFrom(cm => cm.Category.Id));
            CreateMap<UserCharacter, UserCharacterResponseDto>();
            CreateMap<CharacterStatus, CharacterStatusSimplifiedResponseDto>()
                .ForMember(dto => dto.Name, o => o.MapFrom(cs => cs.BasicInformation.Name))
                .ForMember(dto => dto.Title, o => o.MapFrom(cs => cs.BasicInformation.Title));

            CreateMap<Skill, SkillDto>()
                .ForMember(sd => sd.CategoryIds, o => o.MapFrom(s => s.Categories.Select(c => c.Id)));
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
                .ForMember(cs => cs.BasicInformation, o => o.MapFrom(csrd => csrd.GeneralInformation.BasicInfo))
                .ForMember(cs => cs.CharacterClasses, o => o.MapFrom(csrd => csrd.Classes))
                .ForMember(cs => cs.UnspentStatpoints, o => o.MapFrom(csrd => csrd.GeneralInformation.Stats.UnspentStatpoints))
                .ForMember(cs => cs.UnspentSkillpoints, o => o.Ignore())
                .ForMember(cs => cs.Stats, o => o.Ignore())
                .ForMember(cs => cs.CreatedAt, o => o.Ignore())
                .ForMember(cs => cs.UserCharacter, o => o.Ignore())
                .ForMember(cs => cs.UserCharacterId, o => o.Ignore())
                .ForMember(cs => cs.Id, o => o.Ignore())
                .ForMember(cs => cs.Resources, o => o.Ignore());
            CreateMap<BasicInfoRequestDto, BasicInformation>();
            CreateMap<CharacterClassRequestDto, CharacterClass>()
                .ForMember(cs => cs.Id, o => o.Ignore())
                .ForMember(cs => cs.ClassModifiers, o => o.MapFrom(ccrd => ccrd.Modifiers))
                .ForMember(cs => cs.CharacterStatusId, o => o.Ignore())
                .ForMember(cs => cs.Skills, o => o.Ignore())
                .ForMember(cs => cs.CharacterStatus, o => o.Ignore());
            CreateMap<ClassModifierRequestDto, ClassModifier>()
                .ForMember(cs => cs.Id, o => o.Ignore())
                .ForMember(cs => cs.Category, o => o.Ignore())
                .ForMember(cs => cs.AffectedResource, o => o.Ignore())
                .ForMember(cs => cs.Class, o => o.Ignore())
                .ForMember(cs => cs.ClassId, o => o.Ignore());
            CreateMap<ResourceRequestDto, Resource>()
                .ForMember(r => r.Id, o => o.Ignore())
                .ForMember(r => r.BaseStat, o => o.Ignore())
                .ForMember(r => r.BaseStatId, o => o.Ignore())
                .ForMember(r => r.AffectingClassModifiers, o => o.Ignore());
            CreateMap<StatRequestDto, Stat>()
                .ForMember(r => r.Id, o => o.Ignore())
                .ForMember(r => r.AffectingSkillVariables, o => o.Ignore())
                .ForMember(r => r.CharacterStatus, o => o.Ignore())
                .ForMember(r => r.CharacterStatusId, o => o.Ignore());
        }
    }
}
