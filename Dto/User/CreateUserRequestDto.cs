using lms_server.dto.Unit;
using lms_server.dto.Role;
using System.ComponentModel.DataAnnotations;
namespace lms_server.dto.User;

public class CreateUserRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; }
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;
}