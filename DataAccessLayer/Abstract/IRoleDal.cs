using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRoleDal
    {
        Task<List<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetStudentRoleAsync();
        Task<Guid> GetByIdRoleAsync(string roleName); // Gelen rol adinin id'sini cekme
        Task<AppRole> FindByIdRoleAsync(Guid roleId); // Gelen id'ye gore rolu dondurme.
        Task<AppRole> FindByUserRoleAsync(Guid userId); // Gelen user id'ye gore kullanicinin rolunu dondurme.
        Task<IdentityResult> CreateRoleAsync(RoleAddDto roleAddDto);
        Task<IdentityResult> UpdateRoleAsync(RoleUpdateDto roleUpdateDto);
        Task<(IdentityResult identityResult, string? roleName)> DeleteRoleAsync(Guid roleId);
    }
}
