using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IStoryRepository
    {
        Task<IEnumerable<Story>> GetAllStoriesAsync();
        Task<Story> GetStoryByIdAsync(int id);
        Task AddStoryAsync(Story story);
        Task UpdateStoryAsync(Story story);
        Task DeleteStoryAsync(int id);
        Task<IEnumerable<Story>> GetStoriesByPromptIdAsync(int promptId);
        Task<List<Story>> GetStoriesByUserIdAsync(string userId);
    }
}
