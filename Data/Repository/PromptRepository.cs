﻿using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;

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
            await _context.SaveChangesAsync();
        }

        public async Task DeletePromptAsync(int id)
        {
            var prompt = await _context.Prompts.Include(p => p.PromptsReactions)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (prompt != null)
            {
                _context.PromptsReactions.RemoveRange(prompt.PromptsReactions);
                _context.Prompts.Remove(prompt);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<Prompt>> GetAllPromptsASync()
        {
            return await _context.Prompts
                .Include(p => p.PromptsReactions)
                .Include(p => p.User)
                .Include(p => p.Stories)
                .ToListAsync();
        }

        public async Task<Prompt> GetPromptByIdASync(int id)
        {
            var prompt = await _context.Prompts
                .Include(p => p.PromptsReactions)
                .Include(p => p.User)
                .Include(p => p.Stories)
                .FirstOrDefaultAsync(x => x.Id == id);

            return prompt;
        }

        public async Task UpdatePromptAsync(Prompt prompt)
        {
            _context.Prompts.Update(prompt);
            await _context.SaveChangesAsync();
        }
    }
}
