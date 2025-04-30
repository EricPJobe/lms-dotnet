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
            // UserName = userModel.UserName,
            // Email = userModel.Email,
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
            // UserName = userRequest.UserName,
            // Email = userRequest.Email,
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
        // userModel.UserName = userRequest.UserName;
        // userModel.Email = userRequest.Email;
        userModel.CreatedTS = userRequest.CreatedTS;
        userModel.UpdatedTS = userRequest.UpdatedTS;
        userModel.IsActive = userRequest.IsActive;

        return userModel;
    } 
}