using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{

    public class Quest : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }
        public bool IsRoot { get; set; }
        public Tree Tree { get; set; }
        public List<Subtask> Subtasks { get; set; }
        public List<Quest> Children { get; set; }
    }
}