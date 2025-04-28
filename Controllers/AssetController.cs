using lms_server.database;
using lms_server.mapper;
using lms_server.Repositories;
using lms_server.Interfaces;
using lms_server.Helpers;
using lms_server.dto.Asset;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/asset")]
[ApiController]
public class AssetController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IAssetRepository _assetRepository;
    public AssetController(ApplicationDBContext context, IAssetRepository assetRepository) 
    {
        _assetRepository = assetRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var assets = await _assetRepository.GetAllAssetsAsync(new QueryObject(1, 100, "", "", false));
        var assetsDto = assets.Select(asset => asset.ToAssetDto());
        return Ok(assetsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var asset = await _assetRepository.GetAssetByIdAsync(id);

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
        await _assetRepository.CreateAssetAsync(assetModel);
        return CreatedAtAction(nameof(GetById), new { id = assetModel.Id }, assetModel.ToAssetDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAssetRequest assetRequest)
    {
        var assetModel = await _assetRepository.UpdateAssetAsync(id, assetRequest);

        if(assetModel == null)
        {
            return NotFound();
        }
        
        return Ok(assetModel.ToAssetDto());
    }
}