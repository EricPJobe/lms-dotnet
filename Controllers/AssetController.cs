using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Asset;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll() 
    {
        var assets = _context.Asset.Select(asset => asset.ToAssetDto()).ToList();
        return Ok(assets);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var asset = _context.Asset.Find(id);

        if(asset == null)
        {
            return NotFound();
        }
        
        return Ok(asset.ToAssetDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAssetRequest assetRequest)
    {
        var assetModel = assetRequest.ToAssetFromCreateDto();
        _context.Asset.Add(assetModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = assetModel.Id }, assetModel.ToAssetDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateAssetRequest assetRequest)
    {
        var assetModel = _context.Asset.Find(id);

        if(assetModel == null)
        {
            return NotFound();
        }

        assetModel = assetRequest.ToAssetFromUpdateDto(assetModel);
        _context.Asset.Update(assetModel);
        _context.SaveChanges();
        
        return Ok(assetModel.ToAssetDto());
    }
}