using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IPromptReactionRepository
    {
        Task AddPromptReactionAsync(PromptReactions promptReactions);
        Task<IEnumerable<PromptReactions>> GetAllPromptReactionsAsync(); //Read all 
        Task<PromptReactions> GetPromptReactionByIdAsync(int promptReactionsId); // Read by ID
        Task UpdatePromptReactionAsync(PromptReactions promptReactions); // Update a prompt reaction
        Task DeletePromptReactionAsync(int promptReactionsId); // Delete a prompt reaction
    }
}
