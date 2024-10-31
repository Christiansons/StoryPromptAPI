using StoryPromptAPI.Models.DTOs.StoryReactions;

namespace StoryPromptAPI.Services.IServices
{
    public interface IStoryReactionService
    {
        Task<IEnumerable<StoryReactionsDTO>> GetAllReactionsByStoryIdAsync(int storyId);
        Task<IEnumerable<StoryReactionsDTO>> GetAllReactionsByUserIdAsync(string userId);
        Task<StoryReactionsDTO> GetReactionByIdAsync(int id);
        Task<StoryReactionsDTO> AddReactionAsync(CreateStoryReactionsDTO createStoryReactionDto);
        Task UpdateReactionAsync(UpdateStoryReactionsDTO updateStoryReactionDto);
        Task DeleteReactionAsync(int id);
    }
}
