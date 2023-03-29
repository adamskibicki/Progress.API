using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class CharacterClass : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<ClassModifier> ClassModifiers { get; set; }
        public Guid CharacterStatusId { get; set; }
        public CharacterStatus CharacterStatus { get; set; }
    }
}