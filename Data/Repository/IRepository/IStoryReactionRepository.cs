using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IStoryReactionRepository
    {
        Task<IEnumerable<StoryReactions>> GetAllReactionsByStoryIdAsync(int storyId);
        Task<IEnumerable<StoryReactions>> GetAllReactionsByUserIdAsync(string userId);
        Task AddReactionAsync(StoryReactions reaction);
        Task UpdateReactionAsync(StoryReactions reaction);
        Task DeleteReactionAsync(int id);
        Task<StoryReactions> GetReactionByIdAsync(int id);
        Task<StoryReactions> GetReactionByStoryAndUserAsync(int storyId, string userId);
        

    }
}
