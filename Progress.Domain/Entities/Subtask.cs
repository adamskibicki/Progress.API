using Progress.Domain.Common;

namespace Progress.Domain.Entities
{
    public class Subtask : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }
    }
}