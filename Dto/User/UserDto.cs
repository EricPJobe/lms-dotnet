using lms_server.dto.Role;

namespace lms_server.dto.User;

public class UserDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
    public DateTime CreatedTS { get; set; }
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}