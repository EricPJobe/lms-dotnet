namespace lms_server.Models;

public class Account
{
    public int Id { get; set; }
    public string SubType { get; set; } = string.Empty;
    public int? UserID  { get; set; }
    public User? User { get; set; }
    public DateTime? AccountDueTS { get; set; }
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }

    public virtual List<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
    public virtual List<AccountCourses> AccountCourses { get; set; } = new List<AccountCourses>();
}