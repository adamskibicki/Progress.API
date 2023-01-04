using Progress.Application.Persistence.Entities;

namespace Progress.Application.Usecases.Quests.GetAllQuests
{
    public class QuestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }
        public List<QuestDto> Descendants { get; set; }
        public List<Subtask> Subtasks { get; set; }
    }
}
