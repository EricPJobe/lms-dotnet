using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Profile;
using lms_server.Repositories;
using lms_server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/profile")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IProfileRepository _profileRepository;
    public ProfileController(ApplicationDBContext context, IProfileRepository profileRepository) 
    {
        _profileRepository = profileRepository;
        _context = context;
    }
  

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var profiles = await _profileRepository.GetAllProfilesAsync(new QueryObject());
        var profilesDto = profiles.Select(profile => profile.ToProfileDto());
        return Ok(profilesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var profile = await _profileRepository.GetProfileByIdAsync(id);

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
        await _profileRepository.CreateProfileAsync(profileModel);
        return CreatedAtAction(nameof(GetById), new { id = profileModel.Id }, profileModel.ToProfileDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProfileRequest profileRequest)
    {
        var profileModel = await _profileRepository.UpdateProfileAsync(id, profileRequest.ToProfileFromUpdateDto());
        if(profileModel == null)
        {
            return NotFound();
        }

        return Ok(profileModel.ToProfileDto());
    }
}