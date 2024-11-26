using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;
using StoryPromptAPI.Models.DTOs.Prompt;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Services
{
    public class PromptService : IPromptService
    {
        private readonly IPromptRepository _promptRepository;
        public PromptService(IPromptRepository promptRepository)
        {
            _promptRepository = promptRepository;
        }
        public async Task<PromptDTO> AddPromptAsync(CreatePromptDTO createPromptDto)
        {
            var prompt = new Prompt
            {
                UserId = createPromptDto.UserId,
                PromptContent = createPromptDto.PromptContent,
                PromptDateCreated = DateTime.Now
            };

            await _promptRepository.AddPromptAsync(prompt);

            return new PromptDTO
            {
                Id = prompt.Id,
                PromptContent = prompt.PromptContent,
                PromptDateCreated = prompt.PromptDateCreated,
            };
        }

        public async Task DeletePromptAsync(int id)
        {
            await _promptRepository.DeletePromptAsync(id);
        }

        public async Task<IEnumerable<PromptDTO>> GetAllPromptsAsync()
        {
            var prompts = await _promptRepository.GetAllPromptsASync();
            var promptDTOs = new List<PromptDTO>();

            // Manually map from Prompt entity to PromptDTO
            foreach (var prompt in prompts)
            {
                promptDTOs.Add(new PromptDTO
                {
                    Id = prompt.Id,
                    PromptContent = prompt.PromptContent,
                    PromptDateCreated = prompt.PromptDateCreated,
                    UserId = prompt.UserId,
                    
                });
            }

            return promptDTOs;
        }

        public async Task<PromptDTO> GetPromptByIdAsync(int id)
        {
            var prompt = await _promptRepository.GetPromptByIdASync(id);
            if (prompt == null)
            {
                return null; // or throw an exception
            }

            // Manually map from Prompt entity to PromptDTO
            return new PromptDTO
            {
                Id = prompt.Id,
                PromptContent = prompt.PromptContent,
                PromptDateCreated = prompt.PromptDateCreated,
                UserId = prompt.UserId

            };
        }

        public async Task<List<PromptDTO>> GetPromptsByUserIdAsync(string userId)
        {
            var prompts = await _promptRepository.GetPromptsByUserIdAsync(userId);
            return prompts.Select(p => new PromptDTO
            {
                Id = p.Id,
                PromptContent = p.PromptContent,
                PromptDateCreated = p.PromptDateCreated,
                UserId = p.UserId
            }).ToList();
        }

        public async Task UpdatePromptAsync(UpdatePromptDTO updatePromptDto)
        {
            var prompt = await _promptRepository.GetPromptByIdASync(updatePromptDto.Id);
            if (prompt == null)
            {
                throw new KeyNotFoundException("Prompt not found.");
            }

            // Update prompt content
            prompt.PromptContent = updatePromptDto.PromptContent;
            await _promptRepository.UpdatePromptAsync(prompt);
        }
    }
}
