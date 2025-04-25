using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetAll() 
    {
        var courses = await _context.Course.ToListAsync();
        var coursesDto = courses.Select(course => course.ToCourseDto());
        return Ok(coursesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var course = await _context.Course.FindAsync(id);

        if(course == null)
        {
            return NotFound();
        }
        
        return Ok(course.ToCourseDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseRequest courseRequest)
    {
        var courseModel = courseRequest.ToCourseFromCreateDto();
        await _context.Course.AddAsync(courseModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = courseModel.Id }, courseModel.ToCourseDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseRequest courseRequest)
    {
        var courseModel = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);

        if(courseModel == null)
        {
            return NotFound();
        }

        courseModel = courseRequest.ToCourseFromUpdateDto(courseModel);
        // _context.Course.Update(courseModel);
        await _context.SaveChangesAsync();
        
        return Ok(courseModel.ToCourseDto());
    }
}