using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Progress.Application.Usecases.Status
{
    public class StatusDto
    {
        public Guid Id { get; set; }
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
        [JsonConverter(typeof(StringEnumConverter))]
        public CategoryCalculationType CategoryCalculationType { get; set; }
        public string AffectedResourceName { get; set; }
    }

    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayColor { get; set; }
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
        public SkillVariableDto[] Variables { get; set; }
    }

    public class SkillVariableDto
    {
        public string Name { get; set; }
        public int BaseValue { get; set; }
        public string Unit { get; set; }
        /// <summary>
        /// How it affects other calculations
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CategoryCalculationType CategoryCalculationType { get; set; }
        public string BaseVariableName { get; set; }
        public string[] AffectedStatNames { get; set; }
        /// <summary>
        /// How variable is calculated itself
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public VariableCalculationType VariableCalculationType { get; set; }
    }

    public enum VariableCalculationType
    {
        None,
        Additive,
        Reciprocal,
        StaticAdditiveOtherVariableBased
    }

    public enum CategoryCalculationType
    {
        None,
        Additive,
        Reciprocal,
        StaticAdditiveOtherVariableBased,
        Multiplicative,
        MultiplicativeWithBaseAdded
    }

    public enum SkillType
    {
        Active,
        Passive
    }

    public class GeneralInformationDto
    {
        public BasicInformationDto BasicInfo { get; set; }
        public StatsDto Stats { get; set; }
        public UnspentSkillpointsDto Skillpoints { get; set; }
        public ResourceDto[] Resources { get; set; }
    }

    public class ResourceDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string CalculationName { get; set; }
        public string BaseStatName { get; set; }
        public int ResourcePointsPerBaseStatPoint { get; set; }
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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class BasicInformationDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
}