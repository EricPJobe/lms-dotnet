using lms_server.dto.Role;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IRoleRepository
{
    Task<Role> GetRoleByIdAsync(int id);
    Task<List<Role>> GetAllRolesAsync(QueryObject queryObject);
    Task<Role?> CreateRoleAsync(Role role);
    Task<Role?> UpdateRoleAsync(int id, UpdateRoleRequest role);
}
