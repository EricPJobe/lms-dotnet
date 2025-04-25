namespace lms_server.Models;
public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }

    public virtual List<UserRole> UserRoles { get; set; } = new List<UserRole>();
}