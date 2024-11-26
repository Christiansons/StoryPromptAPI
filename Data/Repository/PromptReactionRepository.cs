using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data.Repository
{
    public class PromptReactionRepository : IPromptReactionRepository
    {
        private readonly StoryPromptContext _context;
        public PromptReactionRepository(StoryPromptContext context)
        {
            _context = context;
        }

        public async Task AddReactionAsync(PromptReactions reaction)
        {
            await _context.PromptsReactions.AddAsync(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReactionAsync(int id)
        {
            var reaction = await _context.PromptsReactions.FindAsync(id);
            if (reaction != null)
            {
                _context.PromptsReactions.Remove(reaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PromptReactions>> GetAllReactionsByPromptIdAsync(int promptId)
        {
            return await _context.PromptsReactions
                                  .Where(pr => pr.PromptId == promptId)
                                  .ToListAsync();
        }

        public async Task<IEnumerable<PromptReactions>> GetAllReactionsByUserIdAsync(string userId)
        {
            return await _context.PromptsReactions
                                 .Where(pr => pr.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<PromptReactions> GetReactionByIdAsync(int id)
        {
            var reaction = await _context.PromptsReactions.FindAsync(id);
            return reaction;
        }

        public async Task<PromptReactions> GetReactionByPromptAndUserAsync(int promptId, string userId)
        {
            var reaction = await _context.PromptsReactions
                                  .FirstOrDefaultAsync(pr => pr.PromptId == promptId && pr.UserId == userId);

            return reaction;

        }

        public async Task UpdateReactionAsync(PromptReactions reaction)
        {
            _context.PromptsReactions.Update(reaction);
            await _context.SaveChangesAsync();
        }
    }
}
