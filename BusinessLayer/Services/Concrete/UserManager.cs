using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
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

        public async Task<(IdentityResult identityResult, string? userName)> TDeleteUserAsync(Guid userId)
        {
            return await _userDal.DeleteUserAsync(userId);
        }

        public async Task<List<UserListDto>> TGetAllUsersWithRoleAsync()
        {
            return await _userDal.GetAllUsersWithRoleAsync();
        }

        public async Task<AppUser> TGetAppUserByIdAsync(Guid userId)
        {
            return await _userDal.GetAppUserByIdAsync(userId);
        }

        public async Task<string> TGetUserRoleAsync(AppUser user)
        {
            return await _userDal.GetUserRoleAsync(user);
        }

        public async Task<IdentityResult> TUpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            return await _userDal.UpdateUserAsync(userUpdateDto);
        }
    }
}
