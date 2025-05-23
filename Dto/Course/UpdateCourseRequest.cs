namespace lms_server.dto.Course;

public class UpdateCourseRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public int ProductCategoryId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}