using StoryPromptAPI.Models;
using StoryPromptAPI.Models.DTOs.Story;

namespace StoryPromptAPI.Services.IServices
{
    public interface IStoryService
    {
        Task<IEnumerable<StoryDTO>> GetAllStoriesAsync();
        Task<StoryDTO> GetStoryByIdAsync(int id);
        Task<StoryDTO> AddStoryAsync(CreateStoryDTO createStoryDto);
        Task UpdateStoryAsync(UpdateStoryDTO updateStoryDto);
        Task DeleteStoryAsync(int id);
        Task<IEnumerable<StoryDTO>> GetStoriesByPromptIdAsync(int promptId);
        Task<List<StoryDTO>> GetStoriesByUserIdAsync(string userId);
    }
}
