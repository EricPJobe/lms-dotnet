using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IRoleRepository
{
    Task<Role> GetRoleByIdAsync(int id);
    Task<List<Role>> GetAllRolesAsync(QueryObject queryObject);
    Task<bool> CreateRoleAsync(Role role);
    Task<bool> UpdateRoleAsync(int id, Role role);
}
