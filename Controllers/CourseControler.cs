using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Course;
using lms_server.Repositories;
using lms_server.Interfaces;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using Microsoft.AspNetCore.JsonPatch.Internal;
using lms_server.Models;

namespace lms_server.controllers;

[Route("api/v1/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ICourseRepository _courseRepository;
    private readonly IAccountCoursesRepository _accountCoursesRepository;
    public CourseController(ApplicationDBContext context, ICourseRepository courseRepository, IAccountCoursesRepository accountCoursesRepository) 
    {
        _courseRepository = courseRepository;
        _accountCoursesRepository = accountCoursesRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
    {
        var courses = await _courseRepository.GetAllCoursesAsync(queryObject);
        var coursesDto = courses.Select(course => course.ToCourseDto());
        return Ok(coursesDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var course = await _courseRepository.GetCourseByIdAsync(id);

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
        await _courseRepository.CreateCourseAsync(courseModel);
        return CreatedAtAction(nameof(GetById), new { id = courseModel.Id }, courseModel.ToCourseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseRequest courseRequest)
    {
        var courseModel = await _courseRepository.UpdateCourseAsync(id, courseRequest);
        if(courseModel == null)
        {
            return NotFound();
        }
        
        return Ok(courseModel.ToCourseDto());
    }

     [HttpGet("my-courses/{accountid:int}")]
    // [Authorize]
    public async Task<IActionResult> GetMyCourses([FromRoute] int accountid)
    {

        var accountCourses = await _accountCoursesRepository.GetByAccountIdAsync(accountid);
        var courseIds = accountCourses.Select(ac => ac.CourseId).ToList();
        if (courseIds.Count == 0)
        {
            return NotFound();
        }
           

        var courses = await _courseRepository.GetCoursesByIdsAsync(courseIds);
            
        return Ok(courses);
    }
}