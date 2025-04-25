namespace lms_server.dto.Profile;

public class CreateProfileRequest
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public int? UserID  { get; set; }
    public DateTime CreatedTS { get; set; }
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}