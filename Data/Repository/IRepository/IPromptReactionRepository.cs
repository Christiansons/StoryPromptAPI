using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IPromptReactionRepository
    {
        Task<IEnumerable<PromptReactions>> GetAllReactionsByPromptIdAsync(int promptId);
        Task<IEnumerable<PromptReactions>> GetAllReactionsByUserIdAsync(string userId);
        Task AddReactionAsync(PromptReactions reaction);
        Task UpdateReactionAsync(PromptReactions reaction);
        Task DeleteReactionAsync(PromptReactions reaction);
        Task<PromptReactions> GetReactionByIdAsync(int id);
        Task<PromptReactions> GetReactionByPromptAndUserAsync(int promptId, string userId);
        Task<bool> CheckExisitingUpvote(PromptReactions reaction);
    }
}
