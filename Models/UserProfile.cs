namespace lms_server.Models;
public class UserProfile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProfileId { get; set; }
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual User User { get; set; } = null!;
    public virtual Profile Profile { get; set; } = null!;
}    