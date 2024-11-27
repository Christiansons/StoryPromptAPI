using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Models;
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
        public async Task<IActionResult> AddReaction([FromBody]CreatePromptReactionsDTO reactionDto)
        {

            if (ModelState.IsValid)
            {
                // Find any existing reaction for this user and prompt
                
                PromptReactionsDTO? existingReaction = await _promptReactionService.GetReactionAsync(reactionDto.userId, reactionDto.promptId);

                if (existingReaction != null)
                {
                    if (existingReaction.Reaction == "Upvote")
                    {
                        if (reactionDto.reaction == "Upvote")
                        {
                            // User pressed Upvote again; remove the reaction
                            await _promptReactionService.DeleteReactionAsync(existingReaction);
                        }
                        else if (reactionDto.reaction == "Downvote")
                        {
                            // User pressed Downvote; switch reaction
                            existingReaction.Reaction = "Downvote";
                            await _promptReactionService.UpdateReactionAsync(new UpdatePromptReactionsDTO
                            {
                                Id = existingReaction.Id,
                                Reaction = reactionDto.reaction,
                            });
                        }
                    }
                    else if (existingReaction.Reaction == "Downvote")
                    {
                        if (reactionDto.reaction == "Downvote")
                        {
                            // User pressed Downvote again; remove the reaction
                            await _promptReactionService.DeleteReactionAsync(existingReaction);
                        }
                        else if (reactionDto.reaction == "Upvote")
                        {
                            // User pressed Upvote; switch reaction
                            existingReaction.Reaction = "Upvote";
                            await _promptReactionService.UpdateReactionAsync(new UpdatePromptReactionsDTO
                            {
                                Id = existingReaction.Id,
                                Reaction = reactionDto.reaction,
                            });
                        }
                    }
                }
                else
                {
                    // No existing reaction; add new reaction
                    var newReaction = new CreatePromptReactionsDTO
                    {
                        reaction = reactionDto.reaction,
                        userId = reactionDto.userId,
                        promptId = reactionDto.promptId
                    };

                    await _promptReactionService.AddReactionAsync(newReaction);
                }
                return Ok();
                
            }

            return BadRequest("Invalid reaction data");
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
        public async Task<IActionResult> DeleteReaction(PromptReactionsDTO reaction)
        {
            await _promptReactionService.DeleteReactionAsync(reaction);
            return NoContent();
        }
    }
}
