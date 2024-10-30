using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository
{
    public class StoryReactionRepository : IStoryReactionRepository
    {
        private readonly StoryPromptContext _context;
        public StoryReactionRepository(StoryPromptContext context)
        {
            _context = context;
        }

        public async Task AddStoryReactionAsync(StoryReactions storyReactions)
        {
            await _context.StoriesReactions.AddAsync(storyReactions);
            await SaveChanges();
        }

        public async Task DeleteStoryReactionAsync(int storyReactionsId)
        {
            var storyReaction = await _context.StoriesReactions.FindAsync(storyReactionsId);
            if(storyReaction == null)
            {
                return;
            }
            _context.StoriesReactions.Remove(storyReaction);
            await SaveChanges();
        }

        public async Task<IEnumerable<StoryReactions>> GetAllStoryReactionsAsync()
        {
            var storyReactions = await _context.StoriesReactions.ToListAsync();
            return storyReactions;
        }

        public async Task<StoryReactions> GetStoryReactionByIdAsync(int storyReactionsId)
        {
            var storyReaction = await _context.StoriesReactions.FindAsync(storyReactionsId);
            return storyReaction;
        }

        public async Task UpdateStoryReactionAsync(StoryReactions storyReactions)
        {
            _context.StoriesReactions.Update(storyReactions);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
