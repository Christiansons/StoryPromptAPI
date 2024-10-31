using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IProfileRepository
    {
        Task<Profile> GetProfileByUserIdAsync(string userId);
        Task AddProfileAsync(Profile profile);
        Task UpdateProfileAsync(Profile profile);
        Task DeleteProfileAsync(int id);
    }
}
