namespace lms_server.Models;

public class Account
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SubscriptionType { get; set; } = string.Empty;
    public string? AppUserId  { get; set; }
    public AppUser? AppUser { get; set; } 
    public DateTime? AccountDueTS { get; set; }
    // public DateTime CreatedTS { get; set; } = DateTime.Now;
    // public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }

    // public virtual List<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
    public virtual List<AccountCourses> AccountCourses { get; set; } = new List<AccountCourses>();
}