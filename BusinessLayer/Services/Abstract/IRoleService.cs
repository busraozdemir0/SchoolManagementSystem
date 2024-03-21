using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IRoleService
    {
        Task<List<AppRole>> TGetAllRolesAsync();
        Task<AppRole> TGetStudentRoleAsync();
        Task<Guid> TGetByIdRoleAsync(string roleName);
        Task<AppRole> TFindByIdRoleAsync(Guid roleId);
        Task<IdentityResult> TCreateRoleAsync(RoleAddDto roleAddDto);
        Task<IdentityResult> TUpdateRoleAsync(RoleUpdateDto roleUpdateDto);
        Task<(IdentityResult identityResult, string? roleName)> TDeleteRoleAsync(Guid roleId);
    }
}
