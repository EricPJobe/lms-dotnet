using lms_server.database;
using lms_server.dto.User;
using lms_server.mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public UserController(ApplicationDBContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var users = await _context.User.ToListAsync();
        var userDto = users.Select(user => user.ToUserDto());
        return Ok(userDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _context.User.FindAsync(id);

        if(user == null)
        {
            return NotFound();
        }
        
        return Ok(user.ToUserDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest userRequest)
    {
        var userModel = userRequest.ToUserFromCreateDto();
        await _context.User.AddAsync(userModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest userRequest)
    {
        var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

        if(userModel == null)
        {
            return NotFound();
        }

        userModel = userRequest.ToUserFromUpdateDto(userModel);
        // await _context.User.UpdateAsync(userModel);
        await _context.SaveChangesAsync();
        
        return Ok(userModel.ToUserDto());
    }
}