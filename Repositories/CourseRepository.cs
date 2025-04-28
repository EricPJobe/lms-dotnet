using lms_server.database;
using lms_server.dto.Course;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDBContext _context;
    
    public CourseRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<bool> AssignUnitToCourseAsync(int courseId, List<int> unitIds)
    {
        await _context.UnitCourse.AddRangeAsync(unitIds.Select(unitId => new UnitCourse
        {
            CourseId = courseId,
            UnitId = unitId
        }));

        return await _context.SaveChangesAsync() != 0 ? true : false;   
    }

    public async Task<Course?> CreateCourseAsync(Course course)
    {
        await _context.Course.AddAsync(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<List<Course>> GetAllCoursesAsync(QueryObject queryObject)
    {
        var courses = await _context.Course.ToListAsync();
        return courses;
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        var course = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);
        if (course == null)
        {
            throw new KeyNotFoundException("Course not found");
        }
        return course;
    }

    public async Task<Course?> UpdateCourseAsync(int id, UpdateCourseRequest course)
    {
        var courseModel = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);

        if (courseModel == null)
        {
            return null;
        }

        courseModel.Name = course.Name;
        courseModel.Author = course.Author;
        courseModel.Level = course.Level;
        courseModel.Topic = course.Topic;
        courseModel.IsActive = course.IsActive;
        courseModel.UpdatedTS = DateTime.UtcNow;

        _context.Course.Update(courseModel);
        await _context.SaveChangesAsync();
        return courseModel;
    }
    public async Task<bool> CourseExists(int courseId)
    {
        return await _context.Course.AnyAsync(x => x.Id == courseId);
    }
}
