using Progress.Domain.Common;

namespace Progress.Domain.Entities
{
    public class QuestsTree : BaseEntity
    {
        public Quest RootQuest { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}