using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Course;
using Microsoft.AspNetCore.Mvc;

namespace lms_server.controllers;

[Route("api/v1/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public CourseController(ApplicationDBContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() 
    {
        var courses = _context.Course.Select(course => course.ToCourseDto()).ToList();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var course = _context.Course.Find(id);

        if(course == null)
        {
            return NotFound();
        }
        
        return Ok(course.ToCourseDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCourseRequest courseRequest)
    {
        var courseModel = courseRequest.ToCourseFromCreateDto();
        _context.Course.Add(courseModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = courseModel.Id }, courseModel.ToCourseDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateCourseRequest courseRequest)
    {
        var courseModel = _context.Course.Find(id);

        if(courseModel == null)
        {
            return NotFound();
        }

        courseModel = courseRequest.ToCourseFromUpdateDto(courseModel);
        _context.Course.Update(courseModel);
        _context.SaveChanges();
        
        return Ok(courseModel.ToCourseDto());
    }
}