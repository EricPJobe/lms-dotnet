using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Unit;
using Microsoft.AspNetCore.Mvc;

namespace lms_server.controllers;

[Route("api/v1/unit")]
[ApiController]
public class UnitController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public UnitController(ApplicationDBContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() 
    {
        var units = _context.Unit.Select(unit => unit.ToUnitDto()).ToList();
        return Ok(units);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var unit = _context.Unit.Find(id);

        if(unit == null)
        {
            return NotFound();
        }
        
        return Ok(unit.ToUnitDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUnitRequest unitRequest)
    {
        var unitModel = unitRequest.ToUnitFromCreateDto();
        _context.Unit.Add(unitModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = unitModel.Id }, unitModel.ToUnitDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateUnitRequest unitRequest)
    {
        var unitModel = _context.Unit.Find(id);

        if(unitModel == null)
        {
            return NotFound();
        }

        unitModel = unitRequest.ToUnitFromUpdateDto(unitModel);
        _context.Unit.Update(unitModel);
        _context.SaveChanges();
        
        return Ok(unitModel.ToUnitDto());
    }
}