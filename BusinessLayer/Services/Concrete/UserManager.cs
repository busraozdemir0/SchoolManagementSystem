using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUserDal userDal, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userDal = userDal;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInResult> LoginUserAsync(UserLoginDto userLoginDto)
        {
            return await _userDal.LoginUserAsync(userLoginDto);
        }

        public async Task LogOutUserAsync()
        {
            await _userDal.LogOutUserAsync();
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
      
        public async Task<UserProfileDto> TGetUserProfileAsync()
        {
            return await _userDal.GetUserProfileAsync();
        }
        public async Task<bool> TUserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            return await _userDal.UserProfileUpdateAsync(userProfileDto);
        }

        public async Task<int> TGetUserGradeIdAsync(AppUser user)
        {
            return await _userDal.GetUserGradeIdAsync(user);
        }

        public async Task<IdentityResult> TCreateStudentAsync(UserAddDto userAddDto)
        {
            return await _userDal.CreateStudentAsync(userAddDto);
        }

        public async Task<IdentityResult> TCreateTeacherAsync(UserAddDto userAddDto)
        {
            return await _userDal.CreateTeacherAsync(userAddDto);
        }

        public async Task<IdentityResult> TUpdateStudentAsync(UserUpdateDto userUpdateDto)
        {
            return await _userDal.UpdateStudentAsync(userUpdateDto);
        }

        public async Task<IdentityResult> TUpdateTeacherAsync(UserUpdateDto userUpdateDto)
        {
            return await _userDal.UpdateTeacherAsync(userUpdateDto);
        }

        public async Task<List<AppUser>> GetAllFilterAndIncludeUsersAsync(Expression<Func<AppUser, bool>> filter = null, params Expression<Func<AppUser, object>>[] includeProperties)
        {
            return await _userDal.GetAllFilterAndIncludeUsersAsync();
        }
    }
}
