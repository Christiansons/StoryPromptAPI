using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync(); //Read all 
        Task<User> GetUsrByIdAsync(string userId); // Read by ID
        Task UpdateUserAsync(User user); // Update a user
        Task DeleteUserAsync(string userId); // Delete user
    }
}
