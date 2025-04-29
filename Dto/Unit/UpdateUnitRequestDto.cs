namespace lms_server.dto.Unit;

public class UpdateUnitRequest
{
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public string UnitNumber { get; set; } = string.Empty;
    public int CourseID { get; set; }
    public DateTime CreatedTS { get; set; }
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}