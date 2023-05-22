using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class SkillVariableStat : BaseEntity<Guid>
    {
        public Guid StatId { get; set; }
        public Stat Stat { get; set; }
        public Guid SkillVariableId { get; set; }
        public SkillVariable SkillVariable { get; set; }
    }
}
