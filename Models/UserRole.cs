namespace lms_server.Models;
public class UserRole
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual User User { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}