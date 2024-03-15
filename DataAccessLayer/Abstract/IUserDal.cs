using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal
    {
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<IdentityResult> CreateStudentAsync(UserAddDto userAddDto);
        Task<IdentityResult> CreateTeacherAsync(UserAddDto userAddDto);
        Task<List<UserListDto>> GetAllUsersWithRoleAsync(); // Kullanicilari rolleriyle birlikte listeleme islemi
        Task<AppUser> GetAppUserByIdAsync(Guid userId); // Id'ye gore kullaniciyi dondurecek olan metod
        Task<string> GetUserRoleAsync(AppUser user); // Kullanicinin rolünü getirecek olan metod
        Task<int> GetUserGradeIdAsync(AppUser user); // Kulanici Ogrenciyse Sinif Id bilgisini getirecek
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<IdentityResult> UpdateStudentAsync(UserUpdateDto userUpdateDto);
        Task<IdentityResult> UpdateTeacherAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? userName)> DeleteUserAsync(Guid userId); // Birden fazla geriye deger dondurme islemi
                                                                                              // (IdentityResult identityResult,string? userName) => hem IdentityResulttan bir deger hem de kullanicinin adini dondurmek istedigimiz icin yan yana yazildi (string? => string null deger olabilir)
                                                                                              // Controller'da Item1, Item2 cikmasi yerine identityResult, email seklinde cikacak.
        Task<SignInResult> LoginUserAsync(UserLoginDto userLoginDto);
        Task LogOutUserAsync();
        Task<UserProfileDto> GetUserProfileAsync(); // Login olan kullanicinin bilgilerini getirme islemi
        Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);

        // Kullanicilari iliskili oldugu tablolarla yani ornegin grade ve image tablolarina dahil
        // ederek listelemek icin
        Task<List<AppUser>> GetAllFilterAndIncludeUsersAsync(Expression<Func<AppUser, 
            bool>> filter = null, params Expression<Func<AppUser, object>>[] includeProperties);

    }
}
