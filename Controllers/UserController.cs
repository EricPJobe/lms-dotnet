using lms_server.database;
using lms_server.dto.User;
using lms_server.Interfaces;
using lms_server.mapper;
using lms_server.Repositories;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using lms_server.Models;
using lms_server.dto.Login;

namespace lms_server.controllers;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDBContext _context;
    private readonly IUserRepository _userRepository;
    public UserController(UserManager<User> userManager, ApplicationDBContext context, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _context = context;
        _userManager = userManager;
    }

    // [HttpPost("login")]
    // public async Task<IActionResult> Login(LoginDto loginDto)
    // {

    // }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Title = registerDto.Title,
                IsActive = registerDto.IsActive,
                CreatedTS = DateTime.UtcNow,
                UpdatedTS = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if(roleResult.Succeeded)
                {
                    await _userRepository.AssignRolesToUserAsync(user.Id, new List<int> { 1 });
                    return Ok(
                        new NewUserDto
                        {
                            UserName = user.UserName,
                            Email = user.Email,

                        }
                    );
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            return StatusCode(500, result.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
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
    public async Task<IActionResult> GetById([FromRoute] string id)
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
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequest userRequest)
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