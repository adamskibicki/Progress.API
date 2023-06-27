using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Status.Add
{
    public record SkillRequestDto
    {
        public string Name { get; init; }
        public int Level { get; init; }
        public int Tier { get; init; }
        public SkillType Type { get; init; }
        public bool Enhanced { get; init; }
        public TierDescriptionRequestDto[] TierDescriptions { get; init; }
        public Guid[] CategoryIds { get; init; }
        public SkillVariableRequestDto[] Variables { get; init; }
    }
}