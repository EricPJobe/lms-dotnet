using lms_server.Models;
using lms_server.dto.Asset;

namespace lms_server.mapper;

public static class AssetMapper
{
    public static AssetDto ToAssetDto(this Asset assetModel)
    {
        return new AssetDto
        {
            Id = assetModel.Id,
            AssetType = assetModel.AssetType,
            Reference = assetModel.Reference,
            Description = assetModel.Description,
            CreatedTS = assetModel.CreatedTS,
            UpdatedTS = assetModel.UpdatedTS,
            IsActive = assetModel.IsActive,
        };
    }

    public static Asset ToAssetFromCreateDto(this CreateAssetRequest assetRequest)
    {
        return new Asset
        {
            AssetType = assetRequest.AssetType,
            Reference = assetRequest.Reference,
            Description = assetRequest.Description,
            CreatedTS = assetRequest.CreatedTS,
            UpdatedTS = assetRequest.UpdatedTS,
            IsActive = assetRequest.IsActive,
        };
    }
    public static Asset ToAssetFromUpdateDto(this UpdateAssetRequest assetRequest, Asset assetModel)
    {
        assetModel.AssetType = assetRequest.AssetType;
        assetModel.Reference = assetRequest.Reference;
        assetModel.Description = assetRequest.Description;
        assetModel.CreatedTS = assetRequest.CreatedTS;
        assetModel.UpdatedTS = assetRequest.UpdatedTS;
        assetModel.IsActive = assetRequest.IsActive;

        return assetModel;
    }
}