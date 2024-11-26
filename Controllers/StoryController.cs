using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryPromptAPI.Models.DTOs.Story;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        // GET: api/story
        [HttpGet]
        public async Task<IActionResult> GetAllStories()
        {
            var stories = await _storyService.GetAllStoriesAsync();
            return Ok(stories);
        }

        // GET: api/story/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoryById(int id)
        {
            var story = await _storyService.GetStoryByIdAsync(id);
            if (story == null)
            {
                return NotFound("Story not found.");
            }
            return Ok(story);
        }

        // POST: api/story
        [HttpPost]
        public async Task<IActionResult> AddStory(CreateStoryDTO createStoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdStory = await _storyService.AddStoryAsync(createStoryDto);
            return CreatedAtAction(nameof(GetStoryById), new { id = createdStory.Id }, createdStory);
        }

        // PUT: api/story/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStory(int id, UpdateStoryDTO updateStoryDto)
        {
            if (id != updateStoryDto.Id)
            {
                return BadRequest("Story ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _storyService.UpdateStoryAsync(updateStoryDto);
            return NoContent();
        }

        // DELETE: api/story/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStory(int id)
        {
            await _storyService.DeleteStoryAsync(id);
            return NoContent();
        }

        [HttpGet("prompt/{promptId}")]
        public async Task<IActionResult> GetStoriesForPrompt(int promptId)
        {
            var stories = await _storyService.GetStoriesByPromptIdAsync(promptId);

            if (!stories.Any())
            {
                return NotFound("No stories found for the specified prompt.");
            }

            return Ok(stories);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetStoriesByUser(string userId)
        {
            var stories = await _storyService.GetStoriesByUserIdAsync(userId);
            return Ok(stories);
        }
    }
}
