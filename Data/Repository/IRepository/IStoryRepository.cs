using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IStoryRepository
    {
        Task AddStoryAsync(Story story);
        Task<IEnumerable<Story>> GetAllStoriesAsync(); //Read all 
        Task<Story> GetStoryByIdAsync(int storyId); // Read by ID
        Task UpdateStoryAsync(Story story); // Update a story
        Task DeleteStoryAsync(int storyId); // Delete a story
    }
}
