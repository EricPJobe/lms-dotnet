using lms_server.Models;
using lms_server.dto.User; 
using lms_server.dto.Role;

namespace lms_server.mapper;

public static class UserMapper
{
    public static UserDto ToUserDto(this User userModel)
    {
        return new UserDto
        {
            Id = userModel.Id,
            Title = userModel.Title,
            FirstName = userModel.FirstName,
            LastName = userModel.LastName,
            UserName = userModel.UserName,
            Email = userModel.Email,
            Roles = userModel.Roles.Select(role => new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName,
                CreatedTS = role.CreatedTS,
                UpdatedTS = role.UpdatedTS,
                IsActive = role.IsActive,
            }).ToList(),
            CreatedTS = userModel.CreatedTS,
            UpdatedTS = userModel.UpdatedTS,
            IsActive = userModel.IsActive,
        };
    }

    public static User ToUserFromCreateDto(this CreateUserRequest userRequest)
    {
        return new User
        {
            Id = userRequest.Id,
            Title = userRequest.Title,
            FirstName = userRequest.FirstName,
            LastName = userRequest.LastName,
            UserName = userRequest.UserName,
            Email = userRequest.Email,
            Roles = userRequest.Roles.Select(r => new Role
            {
                Id = r.Id,
                RoleName = r.RoleName,
                CreatedTS = r.CreatedTS,
                UpdatedTS = r.UpdatedTS,
                IsActive = r.IsActive,
            }).ToList(),
            CreatedTS = userRequest.CreatedTS,
            UpdatedTS = userRequest.UpdatedTS,
            IsActive = userRequest.IsActive    
        };
    }
    
    public static User ToUserFromUpdateDto(this UpdateUserRequest userRequest, User userModel)
    {
        userModel.Title = userRequest.Title;
        userModel.FirstName = userRequest.FirstName;
        userModel.LastName = userRequest.LastName;
        userModel.UserName = userRequest.UserName;
        userModel.Email = userRequest.Email;
        userModel.Roles = userRequest.Roles.Select(r => new Role
        {
            Id = r.Id,
            RoleName = r.RoleName,
            CreatedTS = r.CreatedTS,
            UpdatedTS = r.UpdatedTS,
            IsActive = r.IsActive
        }).ToList();
        userModel.CreatedTS = userRequest.CreatedTS;
        userModel.UpdatedTS = userRequest.UpdatedTS;
        userModel.IsActive = userRequest.IsActive;

        return userModel;
    } 
}