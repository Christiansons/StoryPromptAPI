using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly StoryPromptContext _context;
        public ProfileRepository (StoryPromptContext context)
        {
            _context = context;
        }

        public async Task AddProfileAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
        {
            var profileList = await _context.Profiles.ToListAsync();
            return profileList;
        }

        public async Task<Profile> GetProfileByIdAsync(int profileId)
        {
            var profile = await _context.Profiles.FindAsync(profileId);
            return profile;
        }

        public async Task UpdateProfileAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfileAsync(int profileId)
        {
            var profile = await _context.Profiles.FindAsync(profileId);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
            }
            else
            {
                return;
            }

            await _context.SaveChangesAsync();
        }
    }
}
