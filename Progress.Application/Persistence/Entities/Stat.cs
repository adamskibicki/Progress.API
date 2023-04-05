using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class Stat : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public bool IsHidden { get; set; }
        public Guid CharacterStatusId { get; set; }
        public CharacterStatus CharacterStatus { get; set; }
        public List<SkillVariableStat> AffectingSkillVariables { get; set; }
    }
}
