namespace lms_server.dto.Course;

public class UpdateCourseRequest
{
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; } 
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
}