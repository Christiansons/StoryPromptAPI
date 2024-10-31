using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository
{
    public class StoryReactionRepository : IStoryReactionRepository
    {
        private readonly StoryPromptContext _context;
        public StoryReactionRepository(StoryPromptContext context)
        {
            _context = context;
        }

        public async Task AddReactionAsync(StoryReactions reaction)
        {
            await _context.StoriesReactions.AddAsync(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReactionAsync(int id)
        {
            var reaction = await _context.StoriesReactions.FindAsync(id);
            if (reaction != null)
            {
                _context.StoriesReactions.Remove(reaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StoryReactions>> GetAllReactionsByStoryIdAsync(int storyId)
        {
            return await _context.StoriesReactions
                                  .Where(sr => sr.StoryId == storyId)
                                  .ToListAsync();
        }

        public async Task<IEnumerable<StoryReactions>> GetAllReactionsByUserIdAsync(string userId)
        {
            return await _context.StoriesReactions
                                .Where(sr => sr.UserId == userId)
                                .ToListAsync();
        }

        public async Task<StoryReactions> GetReactionByIdAsync(int id)
        {
            var reaction = await _context.StoriesReactions.FindAsync(id);
            return reaction;
        }

        public async Task<StoryReactions> GetReactionByStoryAndUserAsync(int storyId, string userId)
        {
            var reaction = await _context.StoriesReactions
                                .FirstOrDefaultAsync(sr => sr.StoryId == storyId && sr.UserId == userId);

            return reaction;
        }

        public async Task UpdateReactionAsync(StoryReactions reaction)
        {
            _context.StoriesReactions.Update(reaction);
            await _context.SaveChangesAsync();
        }
    }
}
