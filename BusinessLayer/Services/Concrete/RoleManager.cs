using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public async Task<IdentityResult> TCreateRoleAsync(RoleAddDto roleAddDto)
        {
            return await _roleDal.CreateRoleAsync(roleAddDto);
        }

        public async Task<(IdentityResult identityResult, string? roleName)> TDeleteRoleAsync(Guid roleId)
        {
            return await _roleDal.DeleteRoleAsync(roleId);
        }

        public async Task<AppRole> TFindByIdRoleAsync(Guid roleId)
        {
            return await _roleDal.FindByIdRoleAsync(roleId);
        }

        public async Task<AppRole> TFindByUserRoleAsync(Guid userId)
        {
            return await _roleDal.FindByUserRoleAsync(userId);
        }

        public async Task<List<AppRole>> TGetAllRolesAsync()
        {
            return await _roleDal.GetAllRolesAsync();
        }

        public async Task<Guid> TGetByIdRoleAsync(string roleName)
        {
            return await _roleDal.GetByIdRoleAsync(roleName);
        }

        public async Task<AppRole> TGetStudentRoleAsync()
        {
            return await _roleDal.GetStudentRoleAsync();
        }

        public Task<IdentityResult> TUpdateRoleAsync(RoleUpdateDto roleUpdateDto)
        {
            return _roleDal.UpdateRoleAsync(roleUpdateDto);
        }
    }
}
