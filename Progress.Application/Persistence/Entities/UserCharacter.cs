using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class UserCharacter : BaseEntity<Guid>
    {
        public List<CharacterStatus> CharacterStatuses { get; set; }
    }
}
