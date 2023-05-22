using Progress.Application.Persistence.Common;
using System.ComponentModel.DataAnnotations;

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

        public DateTimeOffset CreatedAt { get; set; }

        public Guid UserCharacterId { get; set; }
        public UserCharacter UserCharacter { get; set; }
    }
}
