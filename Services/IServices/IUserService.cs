using StoryPromptAPI.Models.DTOs.User;

namespace StoryPromptAPI.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<UserDTO> AddUserAsync(CreateUserDTO createUserDto);
        Task UpdateUserAsync(UpdateUserDTO updateUserDto);
        Task DeleteUserAsync(string id);
    }
}
