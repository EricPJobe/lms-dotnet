using lms_server.database;
using lms_server.dto.User;
using lms_server.mapper;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll() 
    {
        var users = _context.User.Select(user => user.ToUserDto()).ToList();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var user = _context.User.Find(id);

        if(user == null)
        {
            return NotFound();
        }
        
        return Ok(user.ToUserDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserRequest userRequest)
    {
        var userModel = userRequest.ToUserFromCreateDto();
        _context.User.Add(userModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserRequest userRequest)
    {
        var userModel = _context.User.FirstOrDefault(x => x.Id == id);

        if(userModel == null)
        {
            return NotFound();
        }

        userModel = userRequest.ToUserFromUpdateDto(userModel);
        _context.User.Update(userModel);
        _context.SaveChanges();
        
        return Ok(userModel.ToUserDto());
    }
}