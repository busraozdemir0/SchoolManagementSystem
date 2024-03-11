using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> TCreateUserAsync(UserAddDto userAddDto);
        Task<List<UserListDto>> TGetAllUsersWithRoleAsync();
        Task<AppUser> TGetAppUserByIdAsync(Guid userId); // Id'ye gore kullaniciyi dondurecek olan metod
        Task<string> TGetUserRoleAsync(AppUser user); // Kullanicinin rolünü getirecek olan metod
        Task<IdentityResult> TUpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? userName)> TDeleteUserAsync(Guid userId); // Birden fazla geriye deger dondurme islemi
                                                                                               // (IdentityResult identityResult,string? userName) => hem IdentityResulttan bir deger hem de kullanicinin adini dondurmek istedigimiz icin yan yana yazildi (string? => string null deger olabilir)
                                                                                               // Controller'da Item1, Item2 cikmasi yerine identityResult, email seklinde cikacak.
        Task<SignInResult> LoginUserAsync(UserLoginDto userLoginDto);
        Task LogOutUserAsync();
        Task<UserProfileDto> TGetUserProfileAsync();
        Task<bool> TUserProfileUpdateAsync(UserProfileDto userProfileDto); // Login olan kullanicinin profil guncelleme islemleri
    }
}
