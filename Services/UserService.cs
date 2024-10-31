using Microsoft.AspNetCore.Identity;
using StoryPromptAPI.Models.DTOs.User;
using StoryPromptAPI.Models;
using StoryPromptAPI.Services.IServices;
using StoryPromptAPI.Data.Repository.IRepository;

namespace StoryPromptAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<UserDTO> AddUserAsync(CreateUserDTO createUserDto)
        {
            var user = new User
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
            };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                });
            }

            return userDTOs;
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task UpdateUserAsync(UpdateUserDTO updateUserDto)
        {
            var user = await _userRepository.GetUserByIdAsync(updateUserDto.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("user was not found");
            }
            user.UserName = updateUserDto.UserName;
            user.Email = updateUserDto.Email;
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
