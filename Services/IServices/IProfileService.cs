using StoryPromptAPI.Models.DTOs.Profile;

namespace StoryPromptAPI.Services.IServices
{
    public interface IProfileService
    {
        Task<ProfileDTO> GetProfileByUserIdAsync(string userId);

        Task<ProfileDTO> AddProfileAsync(CreateProfileDTO createProfileDto);
        Task UpdateProfileAsync(UpdateProfileDTO updateProfileDto);
        Task DeleteProfileAsync(int id);
    }
}
