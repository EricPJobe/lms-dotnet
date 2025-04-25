namespace lms_server.dto.Asset;

public class CreateAssetRequest
{
    public int Id { get; set; }
    public string AssetType { get; set; } = string.Empty;
    public int Reference { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; }
    public DateTime UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}