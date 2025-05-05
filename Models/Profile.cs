namespace lms_server.Models;
public class Profile
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string? AppUserId  { get; set; }
    public AppUser AppUser { get; set; } = new AppUser();
    // public DateTime CreatedTS { get; set; } = DateTime.Now;
    // public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}