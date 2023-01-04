using Progress.Application.Persistence.Entities;
using Progress.Application.Quests;

namespace Progress.Infrastructure.Persistence.Database
{
    /// <summary>
    /// Only for testing purposes
    /// </summary>
    public class DummyQuestRepository : IQuestRepository
    {
        public Task<List<Quest>> GetAllAsync(Guid treeId)
        {
            Quest child21 = CreateQuest(21), child22 = CreateQuest(22), child31 = CreateQuest(31), child32 = CreateQuest(32), child33 = CreateQuest(33);
            Quest grandchild321 = CreateQuest(321), grandchild322 = CreateQuest(322), grandchild323 = CreateQuest(323), grandchild331 = CreateQuest(331);
            Quest parent1 = CreateQuest(1), parent2 = CreateQuest(2), parent3 = CreateQuest(3);

            ConnectParentAndChildren(parent2, new List<Quest> { child21, child22 });
            ConnectParentAndChildren(parent3, new List<Quest> { child31, child32, child33 });
            ConnectParentAndChildren(child32, new List<Quest> { grandchild321, grandchild322, grandchild323 });
            ConnectParentAndChildren(child33, new List<Quest> { grandchild331 });

            var quests = new List<Quest>
            {
                parent1, parent2, parent3
            };

            return Task.FromResult(quests);
        }

        private Quest CreateQuest(int marker = 0, Quest parent = null, List<Quest> descendants = null, List<Subtask> subtasks = null)
        {
            return new Quest()
            {
                Id = Guid.NewGuid(),
                Name = $"Just do it! {marker}",
                Description = "Eh, you can do it.",
                RewardExp = 10000 + marker,
                Parent = parent,
                Descendants = descendants ?? new List<Quest>(),
                Subtasks = subtasks ?? new List<Subtask>()
            };
        }

        private void ConnectParentAndChildren(Quest parent, List<Quest> children)
        {
            parent.Descendants = children;
            foreach(Quest child in children)
            {
                child.Parent = parent;
            }
        }
    }
}