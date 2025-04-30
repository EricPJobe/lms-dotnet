using lms_server.dto.User;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(string id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<List<User>> GetAllUsersAsync(QueryObject queryObject);
    Task<User?> CreateUserAsync(User userModel);
    Task<User?> UpdateUserAsync(string id, UpdateUserRequest userDto);
    Task<bool> AssignRolesToUserAsync(string userId, List<int> roleIds);
}