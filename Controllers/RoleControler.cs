using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Role;
using lms_server.Repositories;
using lms_server.Interfaces;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IRoleRepository _roleRepository;
    public RoleController(ApplicationDBContext context, IRoleRepository roleRepository) 
    {
        _roleRepository = roleRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
    {
        var roles = await _roleRepository.GetAllRolesAsync(queryObject);
        var rolesDto = roles.Select(role => role.ToRoleDto());
        return Ok(rolesDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var role = await _roleRepository.GetRoleByIdAsync(id);

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
        await _roleRepository.CreateRoleAsync(roleModel);
        return CreatedAtAction(nameof(GetById), new { id = roleModel.Id }, roleModel.ToRoleDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoleRequest roleRequest)
    {
        var roleModel = await _roleRepository.UpdateRoleAsync(id, roleRequest);

        if(roleModel == null)
        {
            return NotFound();
        }
        
        return Ok(roleModel.ToRoleDto());
    }
}