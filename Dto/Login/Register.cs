using System.ComponentModel.DataAnnotations;

namespace lms_server.dto.Login;
public class RegisterDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;
}