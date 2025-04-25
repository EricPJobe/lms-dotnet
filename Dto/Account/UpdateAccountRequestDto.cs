using lms_server.dto.Course;

namespace lms_server.dto.Account;

public class UpdateAccountRequest
{
    public string SubType { get; set; } = string.Empty;
    public int? UserID  { get; set; }
    public DateTime? AccountDueTS { get; set; }
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}