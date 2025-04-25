using lms_server.Models;
using lms_server.dto.Role;

namespace lms_server.mapper;

public static class RoleMapper
{
    public static RoleDto ToRoleDto(this Role roleModel)
    {
        return new RoleDto
        {
            Id = roleModel.Id,
            RoleName = roleModel.RoleName,
            CreatedTS = roleModel.CreatedTS,
            UpdatedTS = roleModel.UpdatedTS,
            IsActive = roleModel.IsActive,
        };
    }

    public static Role ToRoleFromCreateDto(this CreateRoleRequest roleRequest)
    {
        return new Role
        {
            RoleName = roleRequest.RoleName,
            CreatedTS = roleRequest.CreatedTS,
            UpdatedTS = roleRequest.UpdatedTS,
            IsActive = roleRequest.IsActive,
        };
    }
    public static Role ToRoleFromUpdateDto(this UpdateRoleRequest roleRequest, Role roleModel)
    {
        roleModel.RoleName = roleRequest.RoleName;
        roleModel.CreatedTS = roleRequest.CreatedTS;
        roleModel.UpdatedTS = roleRequest.UpdatedTS;
        roleModel.IsActive = roleRequest.IsActive;

        return roleModel;
    }
}