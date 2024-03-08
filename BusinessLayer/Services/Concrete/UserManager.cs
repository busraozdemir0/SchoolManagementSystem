using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Helpers.Images;
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
        private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUserDal userDal, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IImageHelper imageHelper, IUnitOfWork unitOfWork)
        {
            _userDal = userDal;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _imageHelper = imageHelper;
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
        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            // Resim yukleme islemleri
            var imageUpload = await _imageHelper.Upload($"{userProfileDto.Name} {userProfileDto.Surname}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            return image.Id;
        }
        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            return await _userDal.GetUserProfileAsync();
        }
        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId(); // Giren kisinin id'si
            var user = await TGetAppUserByIdAsync(userId);

            Guid? imageId = user.ImageId; // Giris yapan kullanicinin image id'si

            var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword); // Mevcuttaki sifre dogruysa true donecek.
            if (isVerified && userProfileDto.NewPassword != null) // Eger yeni sifre alanina deger girilmisse sifre degistirme islemi yapilacak.
            {
                var result = await _userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword); // Sifre degisme islemi
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    LogOutUserAsync(); // Sifre degistirildigi icin cikis yaptirdik.
                    await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false); // Ardindan yeni sifreyle otomatikman tekrar giris yaptiriyoruz.

                    _mapper.Map(userProfileDto, user);

                    user.ImageId = imageId;

                    if (userProfileDto.Photo != null) // Eger kullanici resim sectiyse resim yukleme isleminin ardindan ImageId bilgisi guncelleniyor.
                        user.ImageId = await UploadImageForUser(userProfileDto);

                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    return true;
                }

                else
                    return false;
            }
            else if (isVerified)
            {
                await _userManager.UpdateSecurityStampAsync(user);

                _mapper.Map(userProfileDto, user);

                user.ImageId = imageId;

                if (userProfileDto.Photo != null) // Eger kullanici resim sectiyse resim yukleme isleminin ardindan ImageId bilgisi guncelleniyor.
                    user.ImageId = await UploadImageForUser(userProfileDto);

                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveAsync();

                return true;
            }

            else
                return false;
        }

        
    }
}
