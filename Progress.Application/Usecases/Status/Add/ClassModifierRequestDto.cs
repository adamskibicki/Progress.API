using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Status.Add
{
    public record ClassModifierRequestDto(string Description, Guid? CategoryId, int PercentagePointsOfCategoryIncrease, CategoryCalculationType CategoryCalculationType, Guid? AffectedResourceId);
}