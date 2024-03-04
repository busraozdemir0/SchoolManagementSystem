using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.DTOs.Roles;
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
        private readonly IMapper _mapper;

        public EfRoleRepository(RoleManager<AppRole> roleManager, AppDbContext context, IMapper mapper)
        {
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
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

        public async Task<AppRole> FindByIdRoleAsync(Guid roleId)
        {
            return await _roleManager.FindByIdAsync(roleId.ToString());
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleAddDto roleAddDto)
        {
            var mapRole = _mapper.Map<AppRole>(roleAddDto);
            mapRole.ConcurrencyStamp = Guid.NewGuid().ToString(); // Ayni anda iki farkli islem yapiliyorsa bunlarin cakismasini engeller
                                                                  // Ornegin ayni anda ayni verinin guncellenme islemi gibi
            var result = await _roleManager.CreateAsync(mapRole);

            return result;
        }
        public async Task<IdentityResult> UpdateRoleAsync(RoleUpdateDto roleUpdateDto)
        {
            var role = await FindByIdRoleAsync(roleUpdateDto.Id); // Gonderilen rol id'sine gore rolu getirme

            if (role != null)
            {
                role.Id=roleUpdateDto.Id;
                role.Name=roleUpdateDto.Name;
                role.NormalizedName=roleUpdateDto.NormalizedName;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                return await _roleManager.UpdateAsync(role);
            }
            return null; 
        }

        public async Task<(IdentityResult identityResult, string? roleName)> DeleteRoleAsync(Guid roleId)
        {
            var role = await FindByIdRoleAsync(roleId);

            var result=await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
                return (result, role.Name);
            else
                return (result, null);
        }
    }
}
