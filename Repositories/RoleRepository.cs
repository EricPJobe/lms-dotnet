using lms_server.database;
using lms_server.dto.Role;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDBContext _context;
    
    public RoleRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateRoleAsync(Role roleModel)
    {
        var succeeded = await _context.Role.AddAsync(roleModel);
        await _context.SaveChangesAsync();
        return succeeded != null;
    }

    public async Task<List<Role>> GetAllRolesAsync(QueryObject queryObject)
    {
        return await _context.Role.ToListAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        var role = await _context.Role.FirstOrDefaultAsync(x => x.Id == id);
        if (role == null)
        {
            throw new KeyNotFoundException("Role not found");
        }
        return role;
    }

    public async Task<bool> UpdateRoleAsync(int id, Role role)
    {
        var roleModel = await _context.Role.FirstOrDefaultAsync(x => x.Id == id);

        if (roleModel == null)
        {
            return false;
        }

        roleModel.RoleName = role.RoleName;
        roleModel.IsActive = role.IsActive;
        roleModel.UpdatedTS = DateTime.UtcNow;

        _context.Role.Update(roleModel);
        await _context.SaveChangesAsync();
        return true;
    }
}