using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IStoryReactionRepository
    {
        Task AddStoryReactionAsync(StoryReactions storyReactions);
        Task<IEnumerable<StoryReactions>> GetAllStoryReactionsAsync(); //Read all 
        Task<StoryReactions> GetStoryReactionByIdAsync(int storyReactionsId); // Read by ID
        Task UpdateStoryReactionAsync(StoryReactions storyReactions); // Update a story reaction
        Task DeleteStoryReactionAsync(int storyReactionsId); // Delete a story reaction
    }
}
