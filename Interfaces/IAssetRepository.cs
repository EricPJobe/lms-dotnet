using lms_server.dto.Asset;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IAssetRepository
{
    Task<Asset> GetAssetByIdAsync(int id);
    Task<List<Asset>> GetAllAssetsAsync(QueryObject queryObject);
    Task<Asset?> CreateAssetAsync(Asset asset);
    Task<Asset?> UpdateAssetAsync(int id, UpdateAssetRequest asset);
}