using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class QuestsTree : BaseEntity
    {
        public Quest RootQuest { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}