namespace lms_server.Models;
public class AccountCourses
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CourseId { get; set; }
    // public DateTime CreatedTS { get; set; } = DateTime.Now;
    // public DateTime? UpdatedTS { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual Account Account { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}