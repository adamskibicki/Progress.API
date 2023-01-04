using Progress.Application.Persistence.Common;

namespace Progress.Application.Persistence.Entities
{
    public class Subtask : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }
    }
}