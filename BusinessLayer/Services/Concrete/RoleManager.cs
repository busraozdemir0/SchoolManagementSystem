using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
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

        public async Task<List<AppRole>> TGetAllRolesAsync()
        {
            return await _roleDal.GetAllRolesAsync();
        }

        public async Task<Guid> TGetByIdRoleAsync(string roleName)
        {
            return await _roleDal.GetByIdRoleAsync(roleName);
        }
    }
}
