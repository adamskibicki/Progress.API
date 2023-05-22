using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string DisplayColor { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
