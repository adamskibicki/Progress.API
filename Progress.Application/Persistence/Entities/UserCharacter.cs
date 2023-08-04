using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class UserCharacter : BaseEntity<Guid>
    {
        public List<CharacterStatus> CharacterStatuses { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
