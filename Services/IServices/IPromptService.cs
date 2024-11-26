using StoryPromptAPI.Models.DTOs.Prompt;

namespace StoryPromptAPI.Services.IServices
{
    public interface IPromptService
    {
        Task<IEnumerable<PromptDTO>> GetAllPromptsAsync();
        Task<PromptDTO> GetPromptByIdAsync(int id);
        Task<PromptDTO> AddPromptAsync(CreatePromptDTO createPromptDto);
        Task UpdatePromptAsync(UpdatePromptDTO updatePromptDto);
        Task DeletePromptAsync(int id);
        Task<List<PromptDTO>> GetPromptsByUserIdAsync(string userId);
    }
}
