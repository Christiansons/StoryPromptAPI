using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.DTOs.PromptReactions;
using StoryPromptAPI.Models;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Services
{
    public class PromptReactionService : IPromptReactionService
    {
        private readonly IPromptReactionRepository _promptReactionRepository;
        public PromptReactionService(IPromptReactionRepository promptReactionRepository)
        {
            _promptReactionRepository = promptReactionRepository;
        }
        public async Task<PromptReactionsDTO> AddReactionAsync(CreatePromptReactionsDTO createPromptReactionDto)
        {
            var reaction = new PromptReactions
            {
                Reaction = createPromptReactionDto.Reaction,
                PromptId = createPromptReactionDto.PromptId,
                UserId = createPromptReactionDto.UserId
            };

            await _promptReactionRepository.AddReactionAsync(reaction);

            return new PromptReactionsDTO
            {
                Id = reaction.Id,
                Reaction = reaction.Reaction,
                PromptId = reaction.PromptId,
                UserId = reaction.UserId
            };
        }

        public async Task DeleteReactionAsync(int id)
        {
            await _promptReactionRepository.DeleteReactionAsync(id);
        }

        public async Task<IEnumerable<PromptReactionsDTO>> GetAllReactionsByPromptIdAsync(int promptId)
        {
            var reactions = await _promptReactionRepository.GetAllReactionsByPromptIdAsync(promptId);
            var reactionDTOs = new List<PromptReactionsDTO>();

            foreach (var reaction in reactions)
            {
                reactionDTOs.Add(new PromptReactionsDTO
                {
                    Id = reaction.Id,
                    Reaction = reaction.Reaction,
                    PromptId = reaction.PromptId,
                    UserId = reaction.UserId
                });
            }

            return reactionDTOs;
        }

        public async Task<IEnumerable<PromptReactionsDTO>> GetAllReactionsByUserIdAsync(string userId)
        {
            var reactions = await _promptReactionRepository.GetAllReactionsByUserIdAsync(userId);
            var reactionDTOs = new List<PromptReactionsDTO>();

            foreach (var reaction in reactions)
            {
                reactionDTOs.Add(new PromptReactionsDTO
                {
                    Id = reaction.Id,
                    Reaction = reaction.Reaction,
                    PromptId = reaction.PromptId,
                    UserId = reaction.UserId
                });
            }

            return reactionDTOs;

        }

        public async Task<PromptReactionsDTO> GetReactionByIdAsync(int id)
        {
            var reaction = await _promptReactionRepository.GetReactionByIdAsync(id);
            if (reaction == null)
            {
                return null;
            }

            return new PromptReactionsDTO
            {
                Id = reaction.Id,
                Reaction = reaction.Reaction,
                PromptId = reaction.PromptId,
                UserId = reaction.UserId
            };
        }

        public async Task UpdateReactionAsync(UpdatePromptReactionsDTO updatePromptReactionDto)
        {
            var reaction = await _promptReactionRepository.GetReactionByIdAsync(updatePromptReactionDto.Id);
            if (reaction == null)
            {
                throw new KeyNotFoundException("Reaction not found.");
            }

            reaction.Reaction = updatePromptReactionDto.Reaction;
            await _promptReactionRepository.UpdateReactionAsync(reaction);
        }
    }
}
