using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.DTOs.Profile;
using StoryPromptAPI.Models;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task<ProfileDTO> AddProfileAsync(CreateProfileDTO createProfileDto)
        {
            var profile = new Profile
            {
                Description = createProfileDto.Description,
                Picture = createProfileDto.Picture,
                UserId = createProfileDto.UserId,
                ProfileCreated = DateOnly.FromDateTime(DateTime.Now),
            };
            await _profileRepository.AddProfileAsync(profile);

            return new ProfileDTO
            {
                Id = profile.Id,
                Description = profile.Description,
                Picture = profile.Picture,
                UserId = profile.UserId,
                ProfileCreated = profile.ProfileCreated,
            };
        }

        public async Task DeleteProfileAsync(int id)
        {
            await _profileRepository.DeleteProfileAsync(id);
        }


        public async Task<ProfileDTO> GetProfileByUserIdAsync(string userId)
        {
            var profile = await _profileRepository.GetProfileByUserIdAsync(userId);
            if (profile == null)
            {
                return null;
            }

            return new ProfileDTO
            {
                Id = profile.Id,
                Description = profile.Description,
                Picture = profile.Picture,
                ProfileCreated = profile.ProfileCreated,
                UserId = profile.UserId,
            };
        }

        public async Task UpdateProfileAsync(UpdateProfileDTO updateProfileDto)
        {
            var profile = await _profileRepository.GetProfileByUserIdAsync(updateProfileDto.UserId);
            if (profile == null)
            {
                throw new KeyNotFoundException("Profile not found");
            }
            profile.Description = updateProfileDto.Description;
            profile.Picture = updateProfileDto.Picture;
            await _profileRepository.UpdateProfileAsync(profile);
        }
    }
}
