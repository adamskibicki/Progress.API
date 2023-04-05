using Progress.Application.Persistence.Common;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Persistence.Entities
{
    public class ClassModifier : BaseEntity<Guid>
    {
        public string Description { get; set; }
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
        public int PercentagePointsOfCategoryIncrease { get; set; }
        public CategoryCalculationType CategoryCalculationType { get; set; }
        public Guid? AffectedResourceId { get; set; }
        public Resource AffectedResource { get; set; }
        public Guid ClassId { get; set; }
        public CharacterClass Class { get; set; }
    }
}