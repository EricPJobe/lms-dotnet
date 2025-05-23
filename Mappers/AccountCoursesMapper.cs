using lms_server.Models;
using lms_server.dto.AccountCourses;

namespace lms_server.mapper;

public static class AccountCoursesMapper
{
    public static AccountCoursesDto ToAccountCoursesDto(this AccountCourses accountCourse)
    {
        return new AccountCoursesDto
        {
            Id = accountCourse.Id,
            AccountId = accountCourse.AccountId,
            CourseId = accountCourse.CourseId,
            IsActive = accountCourse.IsActive
        };
    }
    public static AccountCourses ToAccountCoursesFromCreateDto(this CreateAccountCoursesRequest dto)
    {
        return new AccountCourses
        {
            AccountId = dto.AccountId,
            CourseId = dto.CourseId,
            IsActive = dto.IsActive
        };
    }
    public static AccountCourses ToAccountCoursesFromUpdateDto(this UpdateAccountCoursesRequest dto)
    {
        return new AccountCourses
        {
            Id = dto.Id,
            AccountId = dto.AccountId,
            CourseId = dto.CourseId,
            IsActive = dto.IsActive
        };
    }
}
