using lms_server.database;
using lms_server.dto.AccountCourses;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class AccountCoursesRepository : IAccountCoursesRepository
{
    private readonly ApplicationDBContext _context;

    public AccountCoursesRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<AccountCourses?> CreateAsync(AccountCourses accountCourse)
    {
        await _context.AccountCourses.AddAsync(accountCourse);
        await _context.SaveChangesAsync();
        return accountCourse ;
    }

    public async Task<List<AccountCourses>> GetAllAsync(QueryObject queryObject)
    {
        var accountCourses = await _context.AccountCourses.ToListAsync();
        return accountCourses;
    }

    public async Task<List<AccountCourses>> GetByAccountAndCourseIdAsync(int accountId, int courseId)
    {
        var accountCourses = await _context.AccountCourses
            .Where(x => x.AccountId == accountId && x.CourseId == courseId)
            .ToListAsync();
        return accountCourses;
    }

    public async Task<List<AccountCourses>> GetByAccountIdAsync(int accountId)
    {
        var accountCourses = await _context.AccountCourses
            .Where(x => x.AccountId == accountId)
            .ToListAsync();
        return accountCourses;
    }

    public async Task<List<AccountCourses>> GetByCourseIdAsync(int courseId)
    {
        var accountCourses = await _context.AccountCourses
            .Where(x => x.CourseId == courseId)
            .ToListAsync();
        return accountCourses;
    }

    public async Task<AccountCourses> GetByIdAsync(int id)
    {
        var accountCourse = await _context.AccountCourses.FirstOrDefaultAsync(x => x.Id == id);
        if (accountCourse == null)
        {
            throw new KeyNotFoundException("AccountCourse not found");
        }
        return accountCourse;
    }

    public async Task<AccountCourses?> UpdateAsync(int id, UpdateAccountCoursesRequest accountCourse)
    {
        var accountCourseModel = await _context.AccountCourses.FirstOrDefaultAsync(x => x.Id == id);

        if (accountCourseModel == null)
        {
            return null;
        }

        accountCourseModel.AccountId = accountCourse.AccountId;
        accountCourseModel.CourseId = accountCourse.CourseId;
        accountCourseModel.IsActive = accountCourse.IsActive;

        _context.AccountCourses.Update(accountCourseModel);
        await _context.SaveChangesAsync();
        return accountCourseModel;
    }

}
