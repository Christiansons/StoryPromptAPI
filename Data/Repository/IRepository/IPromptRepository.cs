using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IPromptRepository
    {
        Task<IEnumerable<Prompt>> GetAllPromptsASync();

        Task<Prompt> GetPromptByIdASync(int id);

        Task AddPromptAsync(Prompt prompt);

        Task UpdatePromptAsync(Prompt prompt);
        Task DeletePromptAsync(int id);
        Task<List<Prompt>> GetPromptsByUserIdAsync(string userId);
    }
}
