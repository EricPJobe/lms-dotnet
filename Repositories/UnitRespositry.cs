using lms_server.dto.Unit;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using lms_server.database;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class UnitRepository : IUnitRepository
{
    private readonly ApplicationDBContext _context;
    
    public UnitRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateUnitAsync(Unit unitModel)
    {
        var succeeded = await _context.Unit.AddAsync(unitModel);
        await _context.SaveChangesAsync();
        return succeeded != null;
    }
    public async Task<List<Unit>> GetAllUnitsAsync(QueryObject queryObject)
    {
        return await _context.Unit.ToListAsync();
    }

    public async Task<Unit?> GetUnitByIdAsync(int id)
    {
       var unit = await _context.Unit.FirstOrDefaultAsync(x => x.Id == id);
       if (unit == null)
        {
            throw new KeyNotFoundException("Role not found");
        }
        return unit;
    }

    public async Task<Unit?> GetUnitByUnitnameAsync(string name)
    {
        var unit = await _context.Unit.FirstOrDefaultAsync(x => x.Name == name);
        if (unit == null)
        {
            throw new KeyNotFoundException("Unit not found");
        }
        return unit;
    }

    public async Task<bool> UpdateUnitAsync(int id, UnitDto userDto)
    {
        var unitModel = await _context.Unit.FirstOrDefaultAsync(x => x.Id == id);

        if (unitModel == null)
        {
            return false;
        }

        unitModel.Name = userDto.Name;
        unitModel.Author = userDto.Author;
        unitModel.Level = userDto.Level;
        unitModel.UnitType = userDto.UnitType;
        unitModel.UnitNumber = userDto.UnitNumber;
        unitModel.UpdatedTS = DateTime.UtcNow;
        unitModel.IsActive = userDto.IsActive;
        unitModel.CourseID = userDto.CourseID;

        _context.Unit.Update(unitModel);
        await _context.SaveChangesAsync();
        return true;
    }
}