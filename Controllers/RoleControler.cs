using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Role;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll() 
    {
        var roles = _context.Role.Select(role => role.ToRoleDto()).ToList();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var role = _context.Role.Find(id);

        if(role == null)
        {
            return NotFound();
        }
        
        return Ok(role.ToRoleDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateRoleRequest roleRequest)
    {
        var roleModel = roleRequest.ToRoleFromCreateDto();
        _context.Role.Add(roleModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = roleModel.Id }, roleModel.ToRoleDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateRoleRequest roleRequest)
    {
        var roleModel = _context.Role.Find(id);

        if(roleModel == null)
        {
            return NotFound();
        }

        roleModel = roleRequest.ToRoleFromUpdateDto(roleModel);
        _context.Role.Update(roleModel);
        _context.SaveChanges();
        
        return Ok(roleModel.ToRoleDto());
    }
}