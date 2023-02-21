using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Progress.Application.Usecases.Status
{
    public class StatusDto
    {
        public GeneralInformationDto GeneralInformation { get; set; }
        public ClassDto[] Classes { get; set; }
        public SkillDto[] GeneralSkills { get; set; }
    }

    public class ClassDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ClassModifierDto[] Modifiers { get; set; }
        public SkillDto[] Skills { get; set; }
    }

    public class ClassModifierDto
    {
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public int PercentagePointsOfCategoryIncrease { get; set; }
    }

    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class SkillDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Tier { get; set; }
        public string[] TierDescriptions { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SkillType Type { get; set; }
        public CategoryDto[] Categories { get; set; }
        public bool Enhanced { get; set; }
    }

    public enum SkillType
    {
        Active,
        Passive
    }

    public class GeneralInformationDto
    {
        public BasicInformationDto BasicInfo { get; set; }
        public ResourcesStatusDto ResourcesStatus { get; set; }
        public StatsDto Stats { get; set; }
        public UnspentSkillpointsDto Skillpoints { get; set; }
    }

    public class UnspentSkillpointsDto
    {
        public int CoreSkillpoints { get; set; }
        public int FourthTierSkillpoints { get; set; }
        public int ThirdTierGeneralSkillpoints { get; set; }
        public int FourthTierGeneralSkillpoints { get; set; }
    }

    public class StatsDto
    {
        public int UnspentStatpoints { get; set; }
        public StatDto[] Stats { get; set; }
    }

    public class StatDto
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class ResourcesStatusDto
    {
        public int MaxHealth { get; set; }
        public int MaxStamina { get; set; }
        public int MaxMana { get; set; }
    }

    public class BasicInformationDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
}