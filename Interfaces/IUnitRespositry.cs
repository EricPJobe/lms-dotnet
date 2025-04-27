using lms_server.dto.Unit;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IUnitRepository
{
    Task<Unit?> GetUnitByIdAsync(int id);
    Task<Unit?> GetUnitByUnitnameAsync(string username);
    Task<List<Unit>> GetAllUnitsAsync(QueryObject queryObject);
    Task<bool> CreateUnitAsync(Unit userModel);
    Task<bool> UpdateUnitAsync(int id, UnitDto user);
}    