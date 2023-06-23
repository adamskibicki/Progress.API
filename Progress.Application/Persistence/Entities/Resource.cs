using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class Resource : BaseEntity<Guid>
    {
        public string DisplayName { get; set; }
        public int ResourcePointsPerBaseStatPoint { get; set; }
        public Guid? BaseStatId { get; set; }
        public Stat BaseStat { get; set; }
        public List<ClassModifier> AffectingClassModifiers { get; set; }
    }
}