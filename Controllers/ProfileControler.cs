using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetAll() 
    {
        var profiles = await _context.Profile.ToListAsync();
        var profilesDto = profiles.Select(profile => profile.ToProfileDto());
        return Ok(profilesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var profile = await _context.Profile.FindAsync(id);

        if(profile == null)
        {
            return NotFound();
        }
        
        return Ok(profile.ToProfileDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProfileRequest profileRequest)
    {
        var profileModel = profileRequest.ToProfileFromCreateDto();
        await _context.Profile.AddAsync(profileModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = profileModel.Id }, profileModel.ToProfileDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProfileRequest profileRequest)
    {
        var profileModel = await _context.Profile.FirstOrDefaultAsync(x => x.Id == id);

        if(profileModel == null)
        {
            return NotFound();
        }

        profileModel = profileRequest.ToProfileFromUpdateDto(profileModel);
        // _context.Profile.Update(profileModel);
        await _context.SaveChangesAsync();
        
        return Ok(profileModel.ToProfileDto());
    }
}