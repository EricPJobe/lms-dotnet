namespace lms_server.Models;
public class UserAccount
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual User User { get; set; } = null!;
    public virtual Account Account { get; set; } = null!;
}    