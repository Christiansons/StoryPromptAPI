using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;
using StoryPromptAPI.Models.DTOs.Prompt;
using StoryPromptAPI.Models.DTOs.PromptReactions;
using StoryPromptAPI.Models.DTOs.User;
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
                    user = new UserDTO
                    {
                        Email = prompt.User.Email,
                        Id = prompt.User.Id,
                        UserName = prompt.User.UserName
                    }
                });
            }

            return promptDTOs;
        }

        //Get prompts ordered by created date
		public async Task<IEnumerable<PromptDTO>> GetNewPromptsAsync()
		{
            var allPrompts = await _promptRepository.GetAllPromptsASync();
            var newPrompts = allPrompts.Select(p => new PromptDTO
            {
                Id = p.Id,
                PromptContent = p.PromptContent,
                PromptDateCreated= p.PromptDateCreated,
                user = new UserDTO
                {
                    Email = p.User.Email,
                    Id = p.UserId,
                    UserName = p.User.UserName
                },
                ReactionCount = (p.PromptsReactions.Where(p => p.Reaction == "Like").Count()) - (p.PromptsReactions.Where(p => p.Reaction == "Dislike").Count()),
                StoryCount = p.Stories.Count()
            }).OrderBy(Dto => Dto.PromptDateCreated)
            .ToList();

            return newPrompts;
		}

        //get prompts ordered by like-count
		public async Task<IEnumerable<PromptDTO>> GetTopPromptsAsync()
		{
			var allPrompts = await _promptRepository.GetAllPromptsASync();
			var topPrompts = allPrompts.Select(p => new PromptDTO
			{
				PromptContent = p.PromptContent,
				PromptDateCreated = p.PromptDateCreated,
				Id = p.Id,
				ReactionCount = (p.PromptsReactions.Where(p => p.Reaction == "Like").Count()) - (p.PromptsReactions.Where(p => p.Reaction == "Dislike").Count()),
				user = new UserDTO
				{
					Email = p.User.Email,
					Id = p.UserId,
					UserName = p.User.UserName,
				},
                StoryCount = p.Stories.Count()
            }).OrderByDescending(Dto => Dto.ReactionCount)
			.ToList();

			return topPrompts;
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
                ReactionCount = (prompt.PromptsReactions.Where(p => p.Reaction == "Like").Count()) - (prompt.PromptsReactions.Where(p => p.Reaction == "Dislike").Count()),
                StoryCount = prompt.Stories.Count(),
                user = new UserDTO
                {
                    Email = prompt.User.Email,
                    Id= prompt.UserId,
                    UserName = prompt.User.UserName
                }
            };
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
