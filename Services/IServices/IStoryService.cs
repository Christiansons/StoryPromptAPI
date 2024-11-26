using StoryPromptAPI.Models.DTOs.Story;

namespace StoryPromptAPI.Services.IServices
{
    public interface IStoryService
    {
        Task<IEnumerable<StoryDTO>> GetAllStoriesAsync();
        Task<IEnumerable<StoryByPromptDTO>> GetAllStoriesForPromptAsync(int promptId);
        Task<StoryDTO> GetStoryByIdAsync(int id);
        Task<StoryDTO> AddStoryAsync(CreateStoryDTO createStoryDto);
        Task UpdateStoryAsync(UpdateStoryDTO updateStoryDto);
        Task DeleteStoryAsync(int id);
        Task<List<StoryDTO>> GetStoriesByUserIdAsync(string userId);

    }
}
