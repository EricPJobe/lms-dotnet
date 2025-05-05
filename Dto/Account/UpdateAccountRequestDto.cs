using lms_server.dto.Course;

namespace lms_server.dto.Account;

public class UpdateAccountRequest
{
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string SubscriptionType { get; set; } = string.Empty;
    public string? AppUserId  { get; set; }
    public DateTime? AccountDueTS { get; set; }
    // public DateTime CreatedTS { get; set; } = DateTime.Now;
    // public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}