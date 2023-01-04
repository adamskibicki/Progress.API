using Progress.Application.Persistence.Entities;

namespace Progress.Application.Quests
{
    public interface IQuestRepository
    {
        Task<List<Quest>> GetAllAsync(Guid treeId);
    }
}