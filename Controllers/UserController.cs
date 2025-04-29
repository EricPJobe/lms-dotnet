using lms_server.database;
using lms_server.dto.User;
using lms_server.Interfaces;
using lms_server.mapper;
using lms_server.Repositories;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IUserRepository _userRepository;
    public UserController(ApplicationDBContext context, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var query = HttpContext.Request.Query;
        var users = await _userRepository.GetAllUsersAsync(queryObject);
        var userDto = users.Select(user => user.ToUserDto());
        return Ok(userDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var user = await _userRepository.GetUserByIdAsync(id);

        if(user == null)
        {
            return NotFound();
        }
        
        return Ok(user.ToUserDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest userRequest)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var userModel = userRequest.ToUserFromCreateDto();
        await _userRepository.CreateUserAsync(userModel);
        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest userRequest)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var userModel = await _userRepository.UpdateUserAsync(id, userRequest);

        if(userModel == null)
        {
            return NotFound();
        }

        return Ok(userModel.ToUserDto());
    }
}