using StoryPromptAPI.Models.DTOs.PromptReactions;

namespace StoryPromptAPI.Services.IServices
{
    public interface IPromptReactionService
    {
        Task<IEnumerable<PromptReactionsDTO>> GetAllReactionsByPromptIdAsync(int promptId);
        Task<IEnumerable<PromptReactionsDTO>> GetAllReactionsByUserIdAsync(string userId);
        Task<PromptReactionsDTO> GetReactionByIdAsync(int id);
        Task<PromptReactionsDTO> AddReactionAsync(CreatePromptReactionsDTO createPromptReactionDto);
        Task UpdateReactionAsync(UpdatePromptReactionsDTO updatePromptReactionDto);
        Task DeleteReactionAsync(int id);
    }
}
