using Progress.Domain.Common;

namespace Progress.Domain.Entities
{

    public class Quest : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }
        public Quest Parent { get; set; }
        public List<Quest> Descendants { get; set; }
        public List<Subtask> Subtasks { get; set; }
    }
}