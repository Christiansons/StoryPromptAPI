using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository.IRepository
{
    public interface IProfileRepository
    {
        Task AddProfileAsync(Profile profile);
        Task<IEnumerable<Profile>> GetAllProfilesAsync(); //Read all profiles
        Task<Profile> GetProfileByIdAsync(int profileId); // Read profile by ID
        Task UpdateProfileAsync(Profile profile); // Update a profile
        Task DeleteProfileAsync(int profileId); // Delete a profile
    }
}
