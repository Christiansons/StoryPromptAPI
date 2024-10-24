using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IPromptRepository
    {
        Task AddPromptAsync(Prompt prompt);
        Task<IEnumerable<Prompt>> GetAllPromptAsync(); //Read all 
        Task<Prompt> GetPromptByIdAsync(int promptId); // Read by ID
        Task UpdatePromptAsync(Prompt prompt); // Update a prompt
        Task DeletePromptAsync(int promptId); // Delete a prompt
    }
}
