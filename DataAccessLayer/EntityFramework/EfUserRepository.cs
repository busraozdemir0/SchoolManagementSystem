using AutoMapper;
using DataAccessLayer.Abstract;
using EntityLayer.DTOs.Users;
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
    public class EfUserRepository : IUserDal
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public EfUserRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);

            var result = await _userManager.CreateAsync(mapUser, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);

            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(mapUser, findRole.ToString());
                return result;
            }
            else
                return result;
        }

        public async Task<List<UserListDto>> GetAllUsersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var mapUser = _mapper.Map<List<UserListDto>>(users);

            foreach (var user in mapUser) // Map'lenmis user'lar uzerinde gez
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString()); // User'in id'sine gore kullaniciyi bul
                var role = string.Join("", await _userManager.GetRolesAsync(findUser)); // Bulunan kullanicinin rolunu bul

                user.Role = role;
            }

            return mapUser;
        }
    }
}
