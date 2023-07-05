using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Status.Add
{
    public record SkillVariableRequestDto
    (
        Guid Id,
        string Name,
        int BaseValue,
        string Unit,
        CategoryCalculationType CategoryCalculationType,
        Guid? BaseSkillVariableId,
        VariableCalculationType VariableCalculationType,
        Guid[] AffectedStatIds
    );
}