using lms_server.Models;
using lms_server.dto.Unit;

namespace lms_server.mapper;

public static class UnitMapper
{
    public static UnitDto ToUnitDto(this Unit unitModel)
    {
        return new UnitDto
        {
            Id = unitModel.Id,
            Name = unitModel.Name,
            Author = unitModel.Author,
            Level = unitModel.Level,
            UnitType = unitModel.UnitType,
            UnitNumber = unitModel.UnitNumber,
            CourseID = unitModel.CourseID,
            // CreatedTS = unitModel.CreatedTS,
            // UpdatedTS = unitModel.UpdatedTS,
            IsActive = unitModel.IsActive,
        };
    }
    public static Unit ToUnitFromCreateDto(this CreateUnitRequest unitRequest)
    {
        return new Unit
        {
            Name = unitRequest.Name,
            Author = unitRequest.Author,
            Level = unitRequest.Level,
            UnitType = unitRequest.UnitType,
            UnitNumber = unitRequest.UnitNumber,
            // CreatedTS = unitRequest.CreatedTS,
            // UpdatedTS = unitRequest.UpdatedTS,
            IsActive = unitRequest.IsActive,
        };
    }
    public static Unit ToUnitFromUpdateDto(this UpdateUnitRequest unitRequest, Unit unitModel)
    {
        unitModel.Name = unitRequest.Name;
        unitModel.Author = unitRequest.Author;
        unitModel.Level = unitRequest.Level;
        unitModel.UnitType = unitRequest.UnitType;
        unitModel.UnitNumber = unitRequest.UnitNumber;
        // unitModel.CreatedTS = unitRequest.CreatedTS;
        // unitModel.UpdatedTS = unitRequest.UpdatedTS;
        unitModel.IsActive = unitRequest.IsActive;

        return unitModel;
    }   
}