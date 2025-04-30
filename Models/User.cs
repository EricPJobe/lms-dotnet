using Microsoft.AspNetCore.Identity;

namespace lms_server.Models;
public class User : IdentityUser
{
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    // public string Password { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual List<Role> Roles { get; set; } = new List<Role>();
    public virtual List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual List<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}