using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryPromptAPI.Models.DTOs.Profile;
using StoryPromptAPI.Services.IServices;
using System.Security.Claims;

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
        public async Task<IActionResult> GetProfileByUserId(string? userId = null)
        {
            //Get the users Id from JWT token
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            //Use UserId from argument if not null, else use Id from token
            var targetUserId = userId ?? loggedInUserId;

            var profile = await _profileService.GetProfileByUserIdAsync(targetUserId);
            if (profile == null)
            {
                return NotFound("Profile not found.");
            }

            var idProfile = new ProfileByIdDTO
            {
                Id = profile.Id,
                Description = profile.Description,
                Picture = profile.Picture,
                ProfileCreated = profile.ProfileCreated,
                UserId = profile.UserId,
                IsOwnProfile = targetUserId == loggedInUserId //Checks if the logged in user is visiting their own profile
            };
            return Ok(idProfile);
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
