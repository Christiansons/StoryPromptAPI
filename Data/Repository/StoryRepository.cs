using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository
{
    public class StoryRepository : IStoryRepository
    {
        private readonly StoryPromptContext _context;

        public StoryRepository(StoryPromptContext context)
        {
            _context = context;
        }
        public async Task AddStoryAsync(Story story)
        {
            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStoryAsync(int id)
        {
            var story = await _context.Stories.Include(s => s.StoriesReactions)
                 .FirstOrDefaultAsync(s => s.Id == id);
            if (story != null)
            {
                _context.StoriesReactions.RemoveRange(story.StoriesReactions);
                _context.Stories.Remove(story);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Story>> GetAllStoriesAsync()
        {
            return await _context.Stories.ToListAsync();
        }

        public async Task<IEnumerable<Story>> GetStoriesByPromptIdAsync(int promptId)
        {
            return await _context.Stories
                                 .Where(story => story.PromptId == promptId)
                                 .ToListAsync();
        }

        public async Task<List<Story>> GetStoriesByUserIdAsync(string userId)
        {
            return await _context.Stories
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.StoryDateCreated)
                .ToListAsync();
        }

        public async Task<Story> GetStoryByIdAsync(int id)
        {
            var story = await _context.Stories.FirstOrDefaultAsync(s => s.Id == id);
            return story;
        }

        public async Task UpdateStoryAsync(Story story)
        {
            _context.Stories.Update(story);
            await _context.SaveChangesAsync();
        }
    }
}
