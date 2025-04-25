namespace lms_server.dto.Role;

public class CreateRoleRequest
{
    public int Id { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; }
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}