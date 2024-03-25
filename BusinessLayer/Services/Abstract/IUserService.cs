using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> TCreateUserAsync(UserAddDto userAddDto);
        Task<IdentityResult> TCreateStudentAsync(UserAddDto userAddDto);
        Task<IdentityResult> TCreateTeacherAsync(UserAddDto userAddDto);
        Task<List<UserListDto>> TGetAllUsersWithRoleAsync();
        Task<List<UserListDto>> TGetAllTeachersWithRoleAsync();
        Task<AppUser> TGetAppUserByIdAsync(Guid userId); // Id'ye gore kullaniciyi dondurecek olan metod
        Task<string> TGetUserRoleAsync(AppUser user); // Kullanicinin rolünü getirecek olan metod
        Task<int> TGetUserGradeIdAsync(AppUser user);
        Task<IdentityResult> TUpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<IdentityResult> TUpdateStudentAsync(UserUpdateDto userUpdateDto);
        Task<IdentityResult> TUpdateTeacherAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? userName)> TDeleteUserAsync(Guid userId); // Birden fazla geriye deger dondurme islemi
                                                                                               // (IdentityResult identityResult,string? userName) => hem IdentityResulttan bir deger hem de kullanicinin adini dondurmek istedigimiz icin yan yana yazildi (string? => string null deger olabilir)
                                                                                               // Controller'da Item1, Item2 cikmasi yerine identityResult, email seklinde cikacak.
        Task<SignInResult> LoginUserAsync(UserLoginDto userLoginDto);
        Task LogOutUserAsync();
        Task<UserProfileDto> TGetUserProfileAsync();
        Task<bool> TUserProfileUpdateAsync(UserProfileDto userProfileDto); // Login olan kullanicinin profil guncelleme islemleri

        // Kullanicilari iliskili oldugu tablolarla yani ornegin grade ve image tablolarina dahil
        // ederek listelemek icin
        Task<List<AppUser>> GetAllFilterAndIncludeUsersAsync(Expression<Func<AppUser, bool>> filter = null, 
            params Expression<Func<AppUser, object>>[] includeProperties);

        Task<HashSet<UserListDto>> TStudentInClassListAsync(List<UserListDto> users); // Giren ogretmenin ders verdigi siniflarda bulunan ogrenciler listesi


    }
}
