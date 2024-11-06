using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.DTOs.Story;
using StoryPromptAPI.Models;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }
        public async Task<StoryDTO> AddStoryAsync(CreateStoryDTO createStoryDto)
        {
            var story = new Story
            {
                StoryContent = createStoryDto.StoryContent,
                PromptId = createStoryDto.PromptId,
                UserId = createStoryDto.UserId,
                StoryDateCreated = DateTime.Now,
            };

            await _storyRepository.AddStoryAsync(story);

            return new StoryDTO
            {
                Id = story.Id,
                StoryContent = story.StoryContent,
                PromptId = story.PromptId,
                UserId = story.UserId,
                StoryDateCreated = story.StoryDateCreated,
            };
        }

        public async Task DeleteStoryAsync(int id)
        {
            await _storyRepository.DeleteStoryAsync(id);
        }

        public async Task<IEnumerable<StoryDTO>> GetAllStoriesAsync()
        {
            var stories = await _storyRepository.GetAllStoriesAsync();
            var storyDTOs = new List<StoryDTO>();

            foreach (var story in stories)
            {
                storyDTOs.Add(new StoryDTO
                {
                    Id = story.Id,
                    StoryContent = story.StoryContent,
                    StoryDateCreated = story.StoryDateCreated,
                    PromptId = story.PromptId,
                    UserId = story.UserId,
                });
            }
            return storyDTOs;
        }

        public async Task<StoryDTO> GetStoryByIdAsync(int id)
        {
            var story = await _storyRepository.GetStoryByIdAsync(id);
            if (story == null)
            {
                return null;
            }

            return new StoryDTO
            {
                Id = story.Id,
                StoryContent = story.StoryContent,
                StoryDateCreated = story.StoryDateCreated,
                PromptId = story.PromptId,
                UserId = story.UserId,
            };
        }

        public async Task UpdateStoryAsync(UpdateStoryDTO updateStoryDto)
        {
            var story = await _storyRepository.GetStoryByIdAsync(updateStoryDto.Id);
            if (story == null)
            {
                throw new KeyNotFoundException("Story not found");
            }

            story.StoryContent = updateStoryDto.StoryContent;
            await _storyRepository.UpdateStoryAsync(story);
        }
    }
}
