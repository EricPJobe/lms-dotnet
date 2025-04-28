using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Unit;
using lms_server.Repositories;
using lms_server.Interfaces;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/unit")]
[ApiController]
public class UnitController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IUnitRepository _unitRepository;
    private readonly ICourseRepository _courseRepository;
    public UnitController(ApplicationDBContext context, IUnitRepository unitRepository, ICourseRepository courseRepository) 
    {
        _unitRepository = unitRepository;
        _context = context;
        _courseRepository = courseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var units = await _unitRepository.GetAllUnitsAsync(new QueryObject(1, 100, "", "", false));
        var unitsDto = units.Select(unit => unit.ToUnitDto());
        return Ok(unitsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var unit = await _unitRepository.GetUnitByIdAsync(id);

        if(unit == null)
        {
            return NotFound();
        }
        
        return Ok(unit.ToUnitDto());
    }

    [HttpPost("{courseId}")]
    public async Task<IActionResult> Create([FromRoute] int courseId, [FromBody] CreateUnitRequest unitRequest)
    {
        if (!await _courseRepository.CourseExists(courseId))
        {
            return NotFound("Course not found");
        }
        var unitModel = unitRequest.ToUnitFromCreateDto();
        await _unitRepository.CreateUnitAsync(unitModel);
        return CreatedAtAction(nameof(GetById), new { id = unitModel.Id }, unitModel.ToUnitDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUnitRequest unitRequest)
    {
        var unitModel = await _unitRepository.UpdateUnitAsync(id, unitRequest);

        if(unitModel == null)
        {
            return NotFound();
        }

        return Ok(unitModel.ToUnitDto());
    }
}