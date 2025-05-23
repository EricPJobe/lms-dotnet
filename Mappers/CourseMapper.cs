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
            Description = courseModel.Description,
            ImageUrl = courseModel.ImageUrl,
            VideoUrl = courseModel.VideoUrl,
            ProductCategoryId = courseModel.ProductCategoryId,
            Author = courseModel.Author,
            Level = courseModel.Level,
            Topic = courseModel.Topic,
            IsActive = courseModel.IsActive,
        };
    }
    public static Course ToCourseFromCreateDto(this CreateCourseRequest courseRequest)
    {
        return new Course
        {
            Name = courseRequest.Name,
            Description = courseRequest.Description,
            ImageUrl = courseRequest.ImageUrl,
            VideoUrl = courseRequest.VideoUrl,
            ProductCategoryId = courseRequest.ProductCategoryId,
            Author = courseRequest.Author,
            Level = courseRequest.Level,
            Topic = courseRequest.Topic,
            IsActive = courseRequest.IsActive,
        };
    }  
    public static Course ToCourseFromUpdateDto(this UpdateCourseRequest courseRequest, Course courseModel)
    {
        courseModel.Name = courseRequest.Name;
        courseModel.Description = courseRequest.Description;
        courseModel.ImageUrl = courseRequest.ImageUrl;
        courseModel.VideoUrl = courseRequest.VideoUrl;
        courseModel.ProductCategoryId = courseRequest.ProductCategoryId;
        courseModel.Author = courseRequest.Author;
        courseModel.Level = courseRequest.Level;
        courseModel.Topic = courseRequest.Topic;
        courseModel.IsActive = courseRequest.IsActive;

        return courseModel;
    } 
}