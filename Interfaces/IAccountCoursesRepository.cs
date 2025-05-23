using lms_server.dto.AccountCourses;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IAccountCoursesRepository
{
    Task<List<AccountCourses>> GetAllAsync(QueryObject queryObject);
    Task<AccountCourses> GetByIdAsync(int id);
    Task<List<AccountCourses>> GetByAccountIdAsync(int accountId);
    Task<List<AccountCourses>> GetByCourseIdAsync(int courseId);
    Task<List<AccountCourses>> GetByAccountAndCourseIdAsync(int accountId, int courseId);
    Task<AccountCourses?> CreateAsync(AccountCourses accountCourse);
    Task<AccountCourses?> UpdateAsync(int id, UpdateAccountCoursesRequest accountCourse);
}