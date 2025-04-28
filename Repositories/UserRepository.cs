using lms_server.dto.User;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using lms_server.database;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDBContext _context;
    
    public UserRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<bool> AssignRolesToUserAsync(int userId, List<int> roleIds)
    {
        await _context.UserRole.AddRangeAsync(roleIds.Select(roleId => new UserRole
        {
            UserId = userId,
            RoleId = roleId
        }));
        return await _context.SaveChangesAsync() != 0 ? true : false;        
    }

    public async Task<User?> CreateUserAsync(User userModel)
    {
        await _context.User.AddAsync(userModel);
        await _context.SaveChangesAsync();
        return userModel;
    }

    public async Task<List<User>> GetAllUsersAsync(QueryObject queryObject)
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }

    public async Task<User?> UpdateUserAsync(int id, UpdateUserRequest userDto)
    {
        var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        if (userModel == null)
        {
            return null;
        }
        
        userModel.Title = userDto.Title;
        userModel.FirstName = userDto.FirstName;
        userModel.LastName = userDto.LastName;
        userModel.UserName = userDto.UserName;
        userModel.Email = userDto.Email;
        userModel.UpdatedTS = DateTime.UtcNow;
        userModel.IsActive = userDto.IsActive;
        
        _context.User.Update(userModel);
        await _context.SaveChangesAsync();
        
        return userModel;    
    }
}
