using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StoryPromptContext _context;
        public UserRepository(StoryPromptContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _context.Users.Include(u => u.Stories)
                 .Include(u => u.PromptsReactions)
                 .Include(u => u.StoriesReactions)
                 .FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                _context.Stories.RemoveRange(user.Stories);
                _context.PromptsReactions.RemoveRange(user.PromptsReactions);
                _context.StoriesReactions.RemoveRange(user.StoriesReactions);

                // Remove the user
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
