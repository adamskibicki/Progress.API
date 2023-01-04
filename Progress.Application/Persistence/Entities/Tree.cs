using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class Tree : BaseEntity<Guid>
    {
        public List<Quest> Quests { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}