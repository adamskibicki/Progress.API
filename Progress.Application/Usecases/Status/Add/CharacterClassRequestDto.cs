using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Status.Add
{
    public class CharacterClassRequestDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ClassModifierRequestDto[] Modifiers { get; set; }
        public dynamic[] Skills { get; set; }
    }

    public record ClassModifierRequestDto(string Description, Guid? CategoryId, int PercentagePointsOfCategoryIncrease, CategoryCalculationType CategoryCalculationType, Guid? AffectedResourceId);
}