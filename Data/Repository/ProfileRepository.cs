using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;

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

        public async Task DeleteProfileAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Profile> GetProfileByUserIdAsync(string userId)
        {
            var user = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            return user;
        }

        public async Task UpdateProfileAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
        }
    }
}
