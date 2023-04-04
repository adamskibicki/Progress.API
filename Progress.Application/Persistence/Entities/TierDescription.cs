using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class TierDescription : BaseEntity<Guid>
    {
        public Guid SkillId { get; set; }
        public Skill Skil { get; set; }
        public int Tier { get; set; }
        public string Description { get; set; }
    }
}
