using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository : IUserDal
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IUnitOfWork _unitOfWork;

        public EfUserRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _unitOfWork = unitOfWork;
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

        public async Task<(IdentityResult identityResult, string? userName)> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return (result, user.UserName); // Birden fazla veri dondurme islemi bu sekilde yapilir.
            else
                return (result, null);
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
        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var getUserWithImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x=>x.Id == userId, i=>i.Image);

            var map=_mapper.Map<UserProfileDto>(getUserWithImage);
            return map;
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await _userManager.GetRolesAsync(user));
        }

        public async Task<SignInResult> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            if (user != null)
                return await _signInManager.PasswordSignInAsync(user,userLoginDto.Password, userLoginDto.RememberMe,false);

            return null;   
        }

        public async Task LogOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var userRole = await GetUserRoleAsync(user); // Kullanicinin rolu

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (userRole != "") // Eger kullaniya atanmis rol varsa(userRole degiskeninden bir deger donerse) oncelikle kullanicinin rolunu kaldiriyoruz.
                    await _userManager.RemoveFromRoleAsync(user, userRole);

                var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString()); // View tarafinda SelectList uzerinden secilmis olan rolun id'sine gore rolu bul
                await _userManager.AddToRoleAsync(user, findRole.Name); // Bulunan rolu guncellenecek olan kullaniciya ata

                return result;
            }
            else
                return result;
        }
    }
}
