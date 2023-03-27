using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class Resource : BaseEntity<Guid>
    {
        public string DisplayName { get; set; }
        //TODO: remove calculationName and base stat name later - change to using ids
        public string CalculationName { get; set; }
        public string BaseStatName { get; set; }
        public int ResourcePointsPerBaseStatPoint { get; set; }
    }
}