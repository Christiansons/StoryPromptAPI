using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryPromptAPI.Models.DTOs.Profile;
using StoryPromptAPI.Services.IServices;

namespace StoryPromptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET: api/profile/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetProfileByUserId(string userId)
        {
            var profile = await _profileService.GetProfileByUserIdAsync(userId);
            if (profile == null)
            {
                return NotFound("Profile not found.");
            }
            return Ok(profile);
        }

        // POST: api/profile
        [HttpPost]
        public async Task<IActionResult> AddProfile(CreateProfileDTO createProfileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProfile = await _profileService.AddProfileAsync(createProfileDto);
            return CreatedAtAction(nameof(GetProfileByUserId), new { userId = createdProfile.UserId }, createdProfile);

        }

        // PUT: api/profile/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(string id, UpdateProfileDTO updateProfileDto)
        {
            if (id != updateProfileDto.UserId)
            {
                return BadRequest("Profile ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _profileService.UpdateProfileAsync(updateProfileDto);
            return NoContent();
        }

        // DELETE: api/profile/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            await _profileService.DeleteProfileAsync(id);
            return NoContent();
        }
    }
}
