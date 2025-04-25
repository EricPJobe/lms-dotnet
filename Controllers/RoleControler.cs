using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public RoleController(ApplicationDBContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var roles = await _context.Role.ToListAsync();
        var rolesDto = roles.Select(role => role.ToRoleDto());
        return Ok(rolesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var role = await _context.Role.FindAsync(id);

        if(role == null)
        {
            return NotFound();
        }
        
        return Ok(role.ToRoleDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequest roleRequest)
    {
        var roleModel = roleRequest.ToRoleFromCreateDto();
        await _context.Role.AddAsync(roleModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = roleModel.Id }, roleModel.ToRoleDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoleRequest roleRequest)
    {
        var roleModel = await _context.Role.FirstOrDefaultAsync(x => x.Id == id);

        if(roleModel == null)
        {
            return NotFound();
        }

        roleModel = roleRequest.ToRoleFromUpdateDto(roleModel);
        // _context.Role.Update(roleModel);
        await _context.SaveChangesAsync();
        
        return Ok(roleModel.ToRoleDto());
    }
}