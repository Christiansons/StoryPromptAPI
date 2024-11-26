using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryPromptAPI.Models.DTOs.Prompt;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ControllerBase
    {
        private readonly IPromptService _promptService;
        public PromptController(IPromptService promptService)
        {
            _promptService = promptService;
        }

        // GET: api/prompt
        [HttpGet]
        public async Task<IActionResult> GetAllPrompts()
        {
            var prompts = await _promptService.GetAllPromptsAsync();
            return Ok(prompts);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPromptsByUser(string userId)
        {
            var prompts = await _promptService.GetPromptsByUserIdAsync(userId);
            return Ok(prompts);
        }

        // GET: api/prompt/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromptById(int id)
        {
            var prompt = await _promptService.GetPromptByIdAsync(id);
            if (prompt == null)
            {
                return NotFound("Prompt not found");
            }
            return Ok(prompt);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrompt(CreatePromptDTO createPromptDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create the prompt and retrieve the generated ID
            var createdPrompt = await _promptService.AddPromptAsync(createPromptDto);

            // Return CreatedAtAction with the newly generated ID
            return CreatedAtAction(nameof(GetPromptById), new { id = createdPrompt.Id }, createdPrompt);
        }

        // PUT: api/prompt/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrompt(int id, UpdatePromptDTO updatePromptDto)
        {
            if (id != updatePromptDto.Id)
            {
                return BadRequest("Prompt ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _promptService.UpdatePromptAsync(updatePromptDto);
            return NoContent();
        }

        // DELETE: api/prompt/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrompt(int id)
        {
            await _promptService.DeletePromptAsync(id);
            return NoContent();
        }
    }
}
