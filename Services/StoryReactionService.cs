using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.DTOs.StoryReactions;
using StoryPromptAPI.Models;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Services
{
    public class StoryReactionService : IStoryReactionService
    {
        private readonly IStoryReactionRepository _storyReactionRepository;

        public StoryReactionService(IStoryReactionRepository storyReactionRepository)
        {
            _storyReactionRepository = storyReactionRepository;
        }
        public async Task<StoryReactionsDTO> AddReactionAsync(CreateStoryReactionsDTO createStoryReactionDto)
        {
            var reaction = new StoryReactions
            {
                Reaction = createStoryReactionDto.Reaction,
                StoryId = createStoryReactionDto.StoryId,
                UserId = createStoryReactionDto.UserId
            };

            await _storyReactionRepository.AddReactionAsync(reaction);

            return new StoryReactionsDTO
            {
                Id = reaction.Id,
                Reaction = reaction.Reaction,
                StoryId = reaction.StoryId,
                UserId = reaction.UserId
            };
        }

        public async Task DeleteReactionAsync(int id)
        {
            await _storyReactionRepository.DeleteReactionAsync(id);
        }

        public async Task<IEnumerable<StoryReactionsDTO>> GetAllReactionsByStoryIdAsync(int storyId)
        {
            var reactions = await _storyReactionRepository.GetAllReactionsByStoryIdAsync(storyId);
            var reactionDTOs = new List<StoryReactionsDTO>();

            foreach (var reaction in reactions)
            {
                reactionDTOs.Add(new StoryReactionsDTO
                {
                    Id = reaction.Id,
                    Reaction = reaction.Reaction,
                    StoryId = reaction.StoryId,
                    UserId = reaction.UserId
                });
            }

            return reactionDTOs;
        }

        public async Task<IEnumerable<StoryReactionsDTO>> GetAllReactionsByUserIdAsync(string userId)
        {
            var reactions = await _storyReactionRepository.GetAllReactionsByUserIdAsync(userId);
            var reactionDTOs = new List<StoryReactionsDTO>();

            foreach (var reaction in reactions)
            {
                reactionDTOs.Add(new StoryReactionsDTO
                {
                    Id = reaction.Id,
                    Reaction = reaction.Reaction,
                    StoryId = reaction.StoryId,
                    UserId = reaction.UserId
                });
            }

            return reactionDTOs;
        }

        public async Task<StoryReactionsDTO> GetReactionByIdAsync(int id)
        {
            var reaction = await _storyReactionRepository.GetReactionByIdAsync(id);
            if (reaction == null)
            {
                return null;
            }

            return new StoryReactionsDTO
            {
                Id = reaction.Id,
                Reaction = reaction.Reaction,
                StoryId = reaction.StoryId,
                UserId = reaction.UserId
            };
        }

        public async Task UpdateReactionAsync(UpdateStoryReactionsDTO updateStoryReactionDto)
        {
            var reaction = await _storyReactionRepository.GetReactionByIdAsync(updateStoryReactionDto.Id);
            if (reaction == null)
            {
                throw new KeyNotFoundException("Reaction not found.");
            }

            reaction.Reaction = updateStoryReactionDto.Reaction;
            await _storyReactionRepository.UpdateReactionAsync(reaction);
        }
    }
}
