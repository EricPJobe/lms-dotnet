using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface ICourseRepository
{
    Task<Course> GetCourseByIdAsync(int id);
    Task<List<Course>> GetAllCoursesAsync(QueryObject queryObject);
    Task<bool> CreateCourseAsync(Course course);
    Task<bool> UpdateCourseAsync(int id, Course course);
    Task<bool> AssignUnitToCourseAsync(int courseId, List<int> unitIds);
}