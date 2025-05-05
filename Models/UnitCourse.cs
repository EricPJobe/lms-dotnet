namespace lms_server.Models;
public class UnitCourse
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public int CourseId { get; set; }
    // public DateTime CreatedTS { get; set; } = DateTime.Now;
    // public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual Unit Unit { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}