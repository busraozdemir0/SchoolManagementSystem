using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal
    {
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<List<UserListDto>> GetAllUsersWithRoleAsync(); // Kullanicilari rolleriyle birlikte listeleme islemi
        Task<AppUser> GetAppUserByIdAsync(Guid userId); // Id'ye gore kullaniciyi dondurecek olan metod
        Task<string> GetUserRoleAsync(AppUser user); // Kullanicinin rolünü getirecek olan metod
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? userName)> DeleteUserAsync(Guid userId); // Birden fazla geriye deger dondurme islemi
                                                                                              // (IdentityResult identityResult,string? userName) => hem IdentityResulttan bir deger hem de kullanicinin adini dondurmek istedigimiz icin yan yana yazildi (string? => string null deger olabilir)
                                                                                              // Controller'da Item1, Item2 cikmasi yerine identityResult, email seklinde cikacak.
        Task<SignInResult> LoginUserAsync(UserLoginDto userLoginDto);
        Task LogOutUserAsync();
        Task<UserProfileDto> GetUserProfileAsync(); // Login olan kullanicinin bilgilerini getirme islemi

    }
}
