using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetAll() 
    {
        var units = await _context.Unit.ToListAsync();
        var unitsDto = units.Select(unit => unit.ToUnitDto());
        return Ok(unitsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var unit = await _context.Unit.FindAsync(id);

        if(unit == null)
        {
            return NotFound();
        }
        
        return Ok(unit.ToUnitDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUnitRequest unitRequest)
    {
        var unitModel = unitRequest.ToUnitFromCreateDto();
        await _context.Unit.AddAsync(unitModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = unitModel.Id }, unitModel.ToUnitDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUnitRequest unitRequest)
    {
        var unitModel = await _context.Unit.FirstOrDefaultAsync(x => x.Id == id);

        if(unitModel == null)
        {
            return NotFound();
        }

        unitModel = unitRequest.ToUnitFromUpdateDto(unitModel);
        // _context.Unit.Update(unitModel);
        await _context.SaveChangesAsync();
        
        return Ok(unitModel.ToUnitDto());
    }
}