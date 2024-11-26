using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryPromptAPI.Models.DTOs.PromptReactions;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptReactionController : ControllerBase
    {
        private readonly IPromptReactionService _promptReactionService;

        public PromptReactionController(IPromptReactionService promptReactionService)
        {
            _promptReactionService = promptReactionService;
        }

        // GET: api/promptreaction/prompt/{promptId}
        [HttpGet("prompt/{promptId}")]
        public async Task<IActionResult> GetReactionsByPrompt(int promptId)
        {
            var reactions = await _promptReactionService.GetAllReactionsByPromptIdAsync(promptId);
            return Ok(reactions);
        }

        // GET: api/promptreaction/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReactionsByUser(string userId)
        {
            var reactions = await _promptReactionService.GetAllReactionsByUserIdAsync(userId);
            return Ok(reactions);
        }

        // POST: api/promptreaction
        [HttpPost]
        public async Task<IActionResult> AddReaction(CreatePromptReactionsDTO createPromptReactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdReaction = await _promptReactionService.AddReactionAsync(createPromptReactionDto);
            return CreatedAtAction(nameof(GetReactionsByPrompt), new { promptId = createdReaction.PromptId }, createdReaction);
        }

        // PUT: api/promptreaction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReaction(int id, UpdatePromptReactionsDTO updatePromptReactionDto)
        {
            if (id != updatePromptReactionDto.Id)
            {
                return BadRequest("Reaction ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _promptReactionService.UpdateReactionAsync(updatePromptReactionDto);
            return NoContent();
        }

        // DELETE: api/promptreaction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaction(int id)
        {
            await _promptReactionService.DeleteReactionAsync(id);
            return NoContent();
        }
    }
}
