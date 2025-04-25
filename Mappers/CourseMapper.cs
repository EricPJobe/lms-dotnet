using lms_server.Models;
using lms_server.dto.Course;

namespace lms_server.mapper;

public static class CourseMapper
{
    public static CourseDto ToCourseDto(this Course courseModel)
    {
        return new CourseDto
        {
            Id = courseModel.Id,
            Name = courseModel.Name,
            Author = courseModel.Author,
            Level = courseModel.Level,
            Topic = courseModel.Topic,
            CreatedTS = courseModel.CreatedTS,
            UpdatedTS = courseModel.UpdatedTS,
            IsActive = courseModel.IsActive,
        };
    }
    public static Course ToCourseFromCreateDto(this CreateCourseRequest courseRequest)
    {
        return new Course
        {
            Name = courseRequest.Name,
            Author = courseRequest.Author,
            Level = courseRequest.Level,
            Topic = courseRequest.Topic,
            CreatedTS = courseRequest.CreatedTS,
            UpdatedTS = courseRequest.UpdatedTS,
            IsActive = courseRequest.IsActive,
        };
    }  
    public static Course ToCourseFromUpdateDto(this UpdateCourseRequest courseRequest, Course courseModel)
    {
        courseModel.Name = courseRequest.Name;
        courseModel.Author = courseRequest.Author;
        courseModel.Level = courseRequest.Level;
        courseModel.Topic = courseRequest.Topic;
        courseModel.CreatedTS = courseRequest.CreatedTS;
        courseModel.UpdatedTS = courseRequest.UpdatedTS;
        courseModel.IsActive = courseRequest.IsActive;

        return courseModel;
    } 
}