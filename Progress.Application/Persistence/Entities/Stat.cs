using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class Stat : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
