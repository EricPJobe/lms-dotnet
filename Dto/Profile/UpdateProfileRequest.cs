namespace lms_server.dto.Profile;

public class UpdateProfileRequest
{
    public string Location { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string? AppUserId  { get; set; }
    // public DateTime CreatedTS { get; set; }
    // public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}