using lms_server.database;
using lms_server.mapper;
using lms_server.dto.AccountCourses;
using lms_server.Interfaces;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace lms_server.controllers;

[Route("api/v1/accountcourses")]
[ApiController]
public class AccountCoursesController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IAccountCoursesRepository _accountCoursesRepository;

    public AccountCoursesController(ApplicationDBContext context, IAccountCoursesRepository accountCoursesRepository) 
    {
        _accountCoursesRepository = accountCoursesRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
    {
        var accountCourses = await _accountCoursesRepository.GetAllAsync(queryObject);
        var accountCoursesDtos = accountCourses.Select(accountCourse => accountCourse.ToAccountCoursesDto());
        return Ok(accountCoursesDtos);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var accountCourse = await _accountCoursesRepository.GetByIdAsync(id);

        if(accountCourse == null)
        {
            return NotFound();
        }
        
        return Ok(accountCourse.ToAccountCoursesDto());
    }
    [HttpGet("account/{accountId:int}")]
    public async Task<IActionResult> GetByAccountId([FromRoute] int accountId)
    {
        var accountCourses = await _accountCoursesRepository.GetByAccountIdAsync(accountId);

        if(accountCourses == null)
        {
            return NotFound();
        }
        
        return Ok(accountCourses.Select(accountCourse => accountCourse.ToAccountCoursesDto()));
    }
    [HttpGet("course/{courseId:int}")]
    public async Task<IActionResult> GetByCourseId([FromRoute] int courseId)
    {
        var accountCourses = await _accountCoursesRepository.GetByCourseIdAsync(courseId);

        if(accountCourses == null)
        {
            return NotFound();
        }
        
        return Ok(accountCourses.Select(accountCourse => accountCourse.ToAccountCoursesDto()));
    }
    [HttpGet("account/{accountId:int}/course/{courseId:int}")]
    public async Task<IActionResult> GetByAccountAndCourseId([FromRoute] int accountId, [FromRoute] int courseId)
    {
        var accountCourses = await _accountCoursesRepository.GetByAccountAndCourseIdAsync(accountId, courseId);

        if(accountCourses == null)
        {
            return NotFound();
        }
        
        return Ok(accountCourses.Select(accountCourse => accountCourse.ToAccountCoursesDto()));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountCoursesRequest accountCourseRequest)
    {
        var accountCourseModel = accountCourseRequest.ToAccountCoursesFromCreateDto();
        await _accountCoursesRepository.CreateAsync(accountCourseModel);
        return CreatedAtAction(nameof(GetById), new { id = accountCourseModel.Id }, accountCourseModel.ToAccountCoursesDto());
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAccountCoursesRequest accountCourseRequest)
    {
        var accountCourseModel = await _accountCoursesRepository.UpdateAsync(id, accountCourseRequest);
        if(accountCourseModel == null)
        {
            return NotFound();
        }
        
        return Ok(accountCourseModel.ToAccountCoursesDto());
    }
}