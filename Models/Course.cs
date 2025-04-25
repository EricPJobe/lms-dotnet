namespace lms_server.Models;
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }

    public virtual List<UnitCourse> UnitCourses { get; set; } = new List<UnitCourse>();
}
