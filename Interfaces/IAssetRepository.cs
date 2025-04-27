using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IAssetRepository
{
    Task<Asset> GetAssetByIdAsync(int id);
    Task<List<Asset>> GetAllAssetsAsync(QueryObject queryObject);
    Task<bool> CreateAssetAsync(Asset asset);
    Task<bool> UpdateAssetAsync(int id, Asset asset);
}