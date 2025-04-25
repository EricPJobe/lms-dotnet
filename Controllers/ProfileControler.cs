using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Profile;
using Microsoft.AspNetCore.Mvc;

namespace lms_server.controllers;

[Route("api/v1/profile")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public ProfileController(ApplicationDBContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() 
    {
        var profiles = _context.Profile.Select(profile => profile.ToProfileDto()).ToList();
        return Ok(profiles);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var profile = _context.Profile.Find(id);

        if(profile == null)
        {
            return NotFound();
        }
        
        return Ok(profile.ToProfileDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProfileRequest profileRequest)
    {
        var profileModel = profileRequest.ToProfileFromCreateDto();
        _context.Profile.Add(profileModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = profileModel.Id }, profileModel.ToProfileDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateProfileRequest profileRequest)
    {
        var profileModel = _context.Profile.Find(id);

        if(profileModel == null)
        {
            return NotFound();
        }

        profileModel = profileRequest.ToProfileFromUpdateDto(profileModel);
        _context.Profile.Update(profileModel);
        _context.SaveChanges();
        
        return Ok(profileModel.ToProfileDto());
    }
}