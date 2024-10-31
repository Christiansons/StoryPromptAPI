using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryPromptAPI.Models.DTOs.StoryReactions;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryReactionController : ControllerBase
    {
        private readonly IStoryReactionService _storyReactionService;

        public StoryReactionController(IStoryReactionService storyReactionService)
        {
            _storyReactionService = storyReactionService;
        }

        // GET: api/storyreaction/story/{storyId}
        [HttpGet("story/{storyId}")]
        public async Task<IActionResult> GetReactionsByStory(int storyId)
        {
            var reactions = await _storyReactionService.GetAllReactionsByStoryIdAsync(storyId);
            return Ok(reactions);
        }

        // GET: api/storyreaction/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReactionsByUser(string userId)
        {
            var reactions = await _storyReactionService.GetAllReactionsByUserIdAsync(userId);
            return Ok(reactions);
        }

        // POST: api/storyreaction
        [HttpPost]
        public async Task<IActionResult> AddReaction(CreateStoryReactionsDTO createStoryReactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdReaction = await _storyReactionService.AddReactionAsync(createStoryReactionDto);
            return CreatedAtAction(nameof(GetReactionsByStory), new { storyId = createdReaction.StoryId }, createdReaction);
        }

        // PUT: api/storyreaction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReaction(int id, UpdateStoryReactionsDTO updateStoryReactionDto)
        {
            if (id != updateStoryReactionDto.Id)
            {
                return BadRequest("Reaction ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _storyReactionService.UpdateReactionAsync(updateStoryReactionDto);
            return NoContent();
        }

        // DELETE: api/storyreaction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaction(int id)
        {
            await _storyReactionService.DeleteReactionAsync(id);
            return NoContent();
        }
    }
}
