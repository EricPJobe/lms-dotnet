using lms_server.database;
using lms_server.dto.Asset;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class AssetRepository : IAssetRepository
{
    private readonly ApplicationDBContext _context;
    
    public AssetRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<Asset?> CreateAssetAsync(Asset asset)
    {
        await _context.Asset.AddAsync(asset);
        await _context.SaveChangesAsync();
        return asset;
    }

    public async Task<List<Asset>> GetAllAssetsAsync(QueryObject queryObject)
    {
        var assets = await _context.Asset.ToListAsync();
        return assets;
    }

    public async Task<Asset> GetAssetByIdAsync(int id)
    {
        var asset = await _context.Asset.FirstOrDefaultAsync(x => x.Id == id);
        if (asset == null)
        {
            throw new KeyNotFoundException("Asset not found");
        }
        return asset;
    }

    public async Task<Asset?> UpdateAssetAsync(int id, UpdateAssetRequest asset)
    {
        var assetModel = await _context.Asset.FirstOrDefaultAsync(x => x.Id == id);

        if (assetModel == null)
        {
            return null;
        }

        assetModel.AssetType = asset.AssetType;
        assetModel.Reference = asset.Reference;
        assetModel.Description = asset.Description;
        assetModel.IsActive = asset.IsActive;
        // assetModel.UpdatedTS = DateTime.UtcNow;
        
        _context.Asset.Update(assetModel);
        await _context.SaveChangesAsync();
        return assetModel;
    }
}
