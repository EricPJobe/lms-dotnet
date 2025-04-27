namespace lms_server.Models;
public class Profile
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public int? UserID  { get; set; }
    public User? User { get; set; }
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}