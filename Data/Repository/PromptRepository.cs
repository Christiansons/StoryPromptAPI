using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.Entities;


namespace StoryPromptAPI.Data.Repository
{
    public class PromptRepository :IPromptRepository
    {
        private readonly StoryPromptContext _context;
        public PromptRepository(StoryPromptContext context)
        {
            _context = context;
        }

        public async Task AddPromptAsync(Prompt prompt)
        {
            await _context.Prompts.AddAsync(prompt);
            await SaveChanges();
        }

        public async Task DeletePromptAsync(int promptId)
        {
            var prompt = await _context.Prompts.FindAsync(promptId);
            if (prompt == null)
            {
                return;
            }

            _context.Prompts.Remove(prompt);
            await SaveChanges();
        }

        public async Task<IEnumerable<Prompt>> GetAllPromptAsync()
        {
            var prompts = await _context.Prompts.ToListAsync();
            return prompts;
        }

        public async Task<Prompt> GetPromptByIdAsync(int promptId)
        {
            var prompt = await _context.Prompts.FindAsync(promptId);
            return prompt;
        }

        public async Task UpdatePromptAsync(Prompt prompt)
        {
            _context.Prompts.Update(prompt);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
