using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfRoleRepository : IRoleDal
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly AppDbContext _context;

        public EfRoleRepository(RoleManager<AppRole> roleManager, AppDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            
            return roles;
        }

        public async Task<Guid> GetByIdRoleAsync(string roleName)
        {
           var roleId= _context.Roles.Where(x => x.Name == roleName).Select(y => y.Id).FirstOrDefault();
            return roleId;
        }
    }
}
