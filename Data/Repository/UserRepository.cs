using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.Entities;

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
            await SaveChanges();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user == null)
            {
                return;
            }
             _context.Remove(user);
            await SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();  
            return users;
        }

        public async Task<User> GetUsrByIdAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
