using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class CharacterStatus : BaseEntity<Guid>
    {
        public BasicInformation BasicInformation { get; set; }

        public List<Resource> Resources { get; set; }

        public int UnspentStatpoints { get; set; }

        public UnspentSkillpoints UnspentSkillpoints { get; set; }

        public List<Stat> Stats { get; set; }

        public List<CharacterClass> CharacterClasses { get; set; }
    }
}
