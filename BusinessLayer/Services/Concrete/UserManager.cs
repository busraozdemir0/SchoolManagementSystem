using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IdentityResult> TCreateUserAsync(UserAddDto userAddDto)
        {
            return await _userDal.CreateUserAsync(userAddDto);
        }

        public async Task<List<UserListDto>> TGetAllUsersWithRoleAsync()
        {
            return await _userDal.GetAllUsersWithRoleAsync();
        }
    }
}
