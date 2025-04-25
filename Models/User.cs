namespace lms_server.Models;
public class User
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
    public virtual List<Role> Roles { get; set; } = new List<Role>();
    public virtual List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual List<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    public virtual List<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}