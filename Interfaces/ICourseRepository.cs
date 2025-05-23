using lms_server.dto.Course;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface ICourseRepository
{
    Task<Course> GetCourseByIdAsync(int id);
    Task<List<Course>> GetAllCoursesAsync(QueryObject queryObject);
    Task<Course?> CreateCourseAsync(Course course);
    Task<Course?> UpdateCourseAsync(int id, UpdateCourseRequest course);
    Task<List<Course>> GetCoursesByIdsAsync(List<int> courseIds);
    Task<bool> AssignUnitToCourseAsync(int courseId, List<int> unitIds);
    Task<bool> CourseExists(int courseId);
}