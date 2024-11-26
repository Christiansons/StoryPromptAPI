using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StoryPromptAPI.Models;
using StoryPromptAPI.Models.DTOs.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using StoryPromptAPI.Data.Repository;
using StoryPromptAPI.Data.Repository.IRepository;

namespace StoryPromptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IProfileRepository _profileRepository;

<<<<<<< HEAD
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtSettings> jwtSettings)
=======

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtSettings> jwtSettings, IProfileRepository profileRepository)
>>>>>>> parent of 8c23729 (rt)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
<<<<<<< HEAD
            
=======
            _profileRepository = profileRepository;

>>>>>>> parent of 8c23729 (rt)
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User { UserName = registerDTO.UserName, Email = registerDTO.Email };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            // Automatically create a profile
            var profile = new Profile
            {
                UserId = user.Id,
                Description = "New user profile",
                Picture = "default.png", // Optional default profile picture
                ProfileCreated = DateOnly.FromDateTime(DateTime.UtcNow)
            };
            await _profileRepository.AddProfileAsync(profile);
            await _userManager.AddToRoleAsync(user, "User");

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!passwordCheck.Succeeded)
            {
                return Unauthorized("Invalid credentials");
            }

<<<<<<< HEAD
            var token = GenerateJwtToken(user);
=======
            var token = await GenerateJwtToken(user);
>>>>>>> parent of 8c23729 (rt)

            return Ok(new { token });
        }

<<<<<<< HEAD
        private string GenerateJwtToken(User user)
=======
        [HttpPost("PromoteToAdmin/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PromoteToAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Assign the "Admin" role
            var result = await _userManager.AddToRoleAsync(user, "Admin");
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok($"User {user.UserName} promoted to Admin");
        }


        private async Task<string> GenerateJwtToken(User user)
>>>>>>> parent of 8c23729 (rt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            // Get user roles
            var roles = await _userManager.GetRolesAsync(user);

            // Create claims using JWT standard names
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id), // "sub" for subject/user ID
            new Claim(JwtRegisteredClaimNames.Email, user.Email), // "email" for email address
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName) // "unique_name" for username
            };

            // Add roles as claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // Using ClaimTypes.Role for roles
            }

            // Define the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
<<<<<<< HEAD
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
=======

                Subject = new ClaimsIdentity(claims),

              

>>>>>>> parent of 8c23729 (rt)
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Create and return the token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
