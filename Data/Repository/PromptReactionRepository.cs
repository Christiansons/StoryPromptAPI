using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data.Repository
{
    public class PromptReactionRepository : IPromptReactionRepository
    {
        private readonly StoryPromptContext _context;
        public PromptReactionRepository(StoryPromptContext context)
        {
            _context = context;
        }

        public async Task AddPromptReactionAsync(PromptReactions promptReactions)
        {
            await _context.PromptsReactions.AddAsync(promptReactions);
            await SaveChanges();
        }

        public async Task DeletePromptReactionAsync(int promptReactionsId)
        {
            var promptReaction = await _context.PromptsReactions.FindAsync(promptReactionsId);
            if(promptReaction == null)
            {
                return;
            }

            _context.PromptsReactions.Remove(promptReaction);
            await SaveChanges();
        }

        public async Task<IEnumerable<PromptReactions>> GetAllPromptReactionsAsync()
        {
            var prompts = await _context.PromptsReactions.ToListAsync();
            return prompts;
        }

        public async Task<PromptReactions> GetPromptReactionByIdAsync(int promptReactionsId)
        {
            var promptReaction = await _context.PromptsReactions.FindAsync(promptReactionsId);
            return promptReaction;
        }

        public async Task UpdatePromptReactionAsync(PromptReactions promptReactions)
        {
            _context.PromptsReactions.Update(promptReactions);
            await SaveChanges(); 
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
