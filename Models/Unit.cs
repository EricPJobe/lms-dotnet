namespace lms_server.Models;
public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public int UnitNumber { get; set; }
    public DateTime CreatedTS { get; set; } = DateTime.Now;
    public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; }
    public int CourseID { get; set; }
    public virtual List<UnitCourse> UnitCourses { get; set; } = new List<UnitCourse>();

}