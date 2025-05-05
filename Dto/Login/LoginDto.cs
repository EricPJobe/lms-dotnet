using System.ComponentModel.DataAnnotations;

namespace lms_server.dto.Login;
public class LoginDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}