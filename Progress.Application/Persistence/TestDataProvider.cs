using Progress.Application.Persistence.Entities;

namespace Progress.Application.Persistence
{
    public class TreeNodeRepresentation
    {
        public TreeNodeRepresentation[] Children { get; set; } = Array.Empty<TreeNodeRepresentation>();
    }
    public static class TestDataProvider
    {
        public static Tree GetTree(TreeNodeRepresentation node)
        {
            var tree = new Tree
            {
                Name = "Test tree",
                Description = "This is a testing tree",
            };

            var allTreeQuests = new List<Quest>();

            var rootQuest = new Quest
            {
                Description = "This is testing root quest",
                Name = "Test root quest",
                IsRoot = true,
                RewardExp = 100,
                Tree = tree,
                Children = node.Children.Select(c => GenerateQuest(c, tree, allTreeQuests)).ToList()
            };
            var subtasks = GenerateSubtasks(rootQuest);
            rootQuest.Subtasks = subtasks;

            allTreeQuests.Add(rootQuest);

            tree.Quests = allTreeQuests;

            return tree;
        }

        private static List<Subtask> GenerateSubtasks(Quest quest)
        {
            return new List<Subtask>()
            {
                new Subtask()
                {
                    Description = "This is test subtask",
                    Name = "Test subtask",
                    Quest = quest,
                    RewardExp = 100,
                },
                new Subtask()
                {
                    Description = "This is test subtask",
                    Name = "Test subtask",
                    Quest = quest,
                    RewardExp = 200,
                }
            };
        }

        private static Quest GenerateQuest(TreeNodeRepresentation node, Tree tree, List<Quest> allTreeQuests)
        {
            var quest = new Quest
            {
                Description = "This is testing quest",
                Name = "Test quest",
                RewardExp = 100,
                IsRoot = false,
                Tree = tree,
                Children = node.Children.Select(c => GenerateQuest(c, tree, allTreeQuests)).ToList(),
            };

            var subtasks = GenerateSubtasks(quest);
            quest.Subtasks = subtasks;
            allTreeQuests.Add(quest);
            return quest;
        }
    }
}
