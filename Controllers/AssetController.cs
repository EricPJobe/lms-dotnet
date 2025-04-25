using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Asset;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/asset")]
[ApiController]
public class AssetController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public AssetController(ApplicationDBContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var assets = await _context.Asset.ToListAsync();
        var assetsDto = assets.Select(asset => asset.ToAssetDto());
        return Ok(assetsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var asset = await _context.Asset.FindAsync(id);

        if(asset == null)
        {
            return NotFound();
        }
        
        return Ok(asset.ToAssetDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAssetRequest assetRequest)
    {
        var assetModel = assetRequest.ToAssetFromCreateDto();
        await _context.Asset.AddAsync(assetModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = assetModel.Id }, assetModel.ToAssetDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAssetRequest assetRequest)
    {
        var assetModel = await _context.Asset.FirstOrDefaultAsync(x => x.Id == id);

        if(assetModel == null)
        {
            return NotFound();
        }

        assetModel = assetRequest.ToAssetFromUpdateDto(assetModel);
        // _context.Asset.Update(assetModel);
        await _context.SaveChangesAsync();
        
        return Ok(assetModel.ToAssetDto());
    }
}