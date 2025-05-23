namespace lms_server.dto.AccountCourses;

public class CreateAccountCoursesRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CourseId { get; set; }
    public bool IsActive { get; set; } = true;
}