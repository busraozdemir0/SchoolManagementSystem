using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using DataAccessLayer.Helpers.Images;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;

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
        private readonly IImageHelper _imageHelper;
        private readonly IRoleDal _roleDal;
        private readonly IGradeDal _gradeDal;
        private readonly ILessonDal _lessonDal;
        private readonly AppDbContext _context;

        public EfUserRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IImageHelper imageHelper, IRoleDal roleDal, AppDbContext context, IGradeDal gradeDal, ILessonDal lessonDal)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            _roleDal = roleDal;
            _context = context;
            _gradeDal = gradeDal;
            _lessonDal = lessonDal;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);

            var result = await _userManager.CreateAsync(mapUser, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);

            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                if (findRole.Name.Equals(RoleConsts.Student)) // Eger eklenen kullanicinin rolu Ogrenci rolundeyse rastgele ogrenci numarası atanacak.
                {
                    Random randomStudentNo = new Random();
                    mapUser.StudentNo = randomStudentNo.Next(1000, 9999);

                    foreach (var user in _userManager.Users)
                    {
                        if (mapUser.StudentNo == user.StudentNo) // Eger var olan bir ogrenci numarasi uretilmisse tekrardan uret
                            mapUser.StudentNo = randomStudentNo.Next(1000, 9999);
                    }
                }
                await _userManager.AddToRoleAsync(mapUser, findRole.ToString());
                await _unitOfWork.SaveAsync();

                return result;
            }
            else
                return result;
        }

        public async Task<IdentityResult> CreateStudentAsync(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);

            var result = await _userManager.CreateAsync(mapUser, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);

            if (result.Succeeded)
            {
                var findStudentRoleId = await _roleDal.GetByIdRoleAsync(RoleConsts.Student); // Ogrenci rolu
                var findRole = await _roleManager.FindByIdAsync(findStudentRoleId.ToString());

                Random randomStudentNo = new Random();
                mapUser.StudentNo = randomStudentNo.Next(1000, 9999);

                foreach (var user in _userManager.Users)
                {
                    if (mapUser.StudentNo == user.StudentNo) // Eger var olan bir ogrenci numarasi uretilmisse tekrardan uret
                        mapUser.StudentNo = randomStudentNo.Next(1000, 9999);
                }

                await _userManager.AddToRoleAsync(mapUser, findRole.ToString());

                await _unitOfWork.SaveAsync();
                return result;
            }
            else
                return result;
        }
        public async Task<IdentityResult> CreateTeacherAsync(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);

            var result = await _userManager.CreateAsync(mapUser, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);

            if (result.Succeeded)
            {
                var findTeacherRoleId = await _roleDal.GetByIdRoleAsync(RoleConsts.Teacher); // Ogretmen rolu
                var findRole = await _roleManager.FindByIdAsync(findTeacherRoleId.ToString());

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

        public async Task<List<AppUser>> GetAllFilterAndIncludeUsersAsync(Expression<Func<AppUser, bool>> filter = null, params Expression<Func<AppUser, object>>[] includeProperties)
        {
            IQueryable<AppUser> query = _context.Users;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                    query = query.Include(item);
            }

            return (await query.ToListAsync());
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

                var userInclude = await GetAllFilterAndIncludeUsersAsync(x => x.Id == user.Id, g => g.Grade, i => i.Image);
                foreach (var item in userInclude.ToList())
                {
                    user.Grade = item.Grade;
                }
            }
            return mapUser;
        }

        public async Task<List<UserListDto>> GetAllTeachersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var mapUser = _mapper.Map<List<UserListDto>>(users);
            List<UserListDto> teachers = new();

            foreach (var user in mapUser) // Map'lenmis user'lar uzerinde gez
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString()); // User'in id'sine gore kullaniciyi bul
                var role = string.Join("", await _userManager.GetRolesAsync(findUser)); // Bulunan kullanicinin rolunu bul
                user.Role = role;

                if (role == RoleConsts.Teacher)
                    teachers.Add(user);

                var userInclude = await GetAllFilterAndIncludeUsersAsync(x => x.Id == user.Id, g => g.Grade, i => i.Image);
                foreach (var item in userInclude.ToList())
                {
                    user.TeacherInfo = "Ad: " + item.Name + " " + item.Surname + " ~ Email: " + item.Email;
                }
            }
            return teachers;
        }

        public async Task<List<UserListDto>> GetAllStudentsWithRoleAsync()  // Ogrenci kullanicilari listeleniyor
        {
            var users = await _userManager.Users.ToListAsync();
            var mapUser = _mapper.Map<List<UserListDto>>(users);
            List<UserListDto> students = new();

            foreach (var user in mapUser) // Map'lenmis user'lar uzerinde gez
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString()); // User'in id'sine gore kullaniciyi bul
                var role = string.Join("", await _userManager.GetRolesAsync(findUser)); // Bulunan kullanicinin rolunu bul
                user.Role = role;

                if (role == RoleConsts.Student)
                    students.Add(user);

                var userInclude = await GetAllFilterAndIncludeUsersAsync(x => x.Id == user.Id, g => g.Grade, i => i.Image);
                foreach (var item in userInclude.ToList())
                {
                    user.Grade = item.Grade;
                }
            }
            return students;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var getUserWithImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, i => i.Image);

            var map = _mapper.Map<UserProfileDto>(getUserWithImage);
            return map;
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await _userManager.GetRolesAsync(user));
        }
        public async Task<int> GetUserGradeIdAsync(AppUser user)
        {
            var grade = await _unitOfWork.GetRepository<Grade>().GetAsync(x => x.Id == user.GradeId);
            return grade.Id;
        }

        public async Task<SignInResult> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            if (user != null)
                return await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);

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

            var selectRole = await _roleDal.FindByIdRoleAsync(userUpdateDto.RoleId);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (userRole != "") // Eger kullaniya atanmis rol varsa(userRole degiskeninden bir deger donerse) oncelikle kullanicinin rolunu kaldiriyoruz.
                    await _userManager.RemoveFromRoleAsync(user, userRole);

                var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString()); // View tarafinda SelectList uzerinden secilmis olan rolun id'sine gore rolu bul
                await _userManager.AddToRoleAsync(user, findRole.Name); // Bulunan rolu guncellenecek olan kullaniciya ata

                if (!(selectRole.Name == RoleConsts.Student)) // Eger kullanici guncelleme esnasinda secilen rol Ogrenci'den farkliysa GradeId ve StudentNo bilgisini null yap
                {
                    user.GradeId = null;
                    user.StudentNo = null;
                }

                else // Eger rol Ogrenci secilmisse ve StudentNo alanı null ise o kullaniciya numara atama
                     // islemi gerceklesecek.
                {
                    if (user.StudentNo is null)
                    {
                        Random randomStudentNo = new Random();
                        user.StudentNo = randomStudentNo.Next(1000, 9999);

                        foreach (var item in _userManager.Users)
                        {
                            if (user.StudentNo == item.StudentNo) // Eger var olan bir ogrenci numarasi uretilmisse tekrardan uret
                                user.StudentNo = randomStudentNo.Next(1000, 9999);
                        }
                    }
                }
                await _unitOfWork.SaveAsync();

                return result;
            }
            else
                return result;
        }

        public async Task<IdentityResult> UpdateStudentAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var studentRole = await _roleDal.GetByIdRoleAsync(RoleConsts.Student); // Student rolu

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {

                var findRole = await _roleManager.FindByIdAsync(studentRole.ToString()); // Student rolunun id'sini bul
                await _userManager.AddToRoleAsync(user, findRole.Name);

                return result;
            }
            else
                return result;
        }

        public async Task<IdentityResult> UpdateTeacherAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var teacherRole = await _roleDal.GetByIdRoleAsync(RoleConsts.Teacher); // Teacher rolu

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {

                var findRole = await _roleManager.FindByIdAsync(teacherRole.ToString()); // Teacher rolunun id'sini bul
                await _userManager.AddToRoleAsync(user, findRole.Name);

                return result;
            }
            else
                return result;
        }

        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            // Resim yukleme islemleri
            var imageUpload = await _imageHelper.Upload($"{userProfileDto.Name} {userProfileDto.Surname}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            return image.Id;
        }
        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId(); // Giren kisinin id'si
            var user = await GetAppUserByIdAsync(userId);

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

        public async Task<HashSet<UserListDto>> StudentInClassListAsync(List<UserListDto> users)
        { 
            var lessons = await _lessonDal.GetAllTeacherLessonsAsync(); // Login olan ogretmenin verdigi dersler listeleniyor.
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);

            HashSet<UserListDto> teacherStudents = new(); // Login olan ogretmenin girdigi siniflarin tutulacagi liste. (HashSet yapisi tekrarsiz veri tutmasini saglayacak)
                                                          // İlgili dto'da IEquatable<GradeListDto> arayuzu implemente edildi ve ilgili metotlarin ici dolduruldu.

            foreach (var lesson in mapLessons)
            {
                var grade = await _gradeDal.GetGradeByIdAsync(lesson.GradeId); // Dersin ait oldugu sinifin id'sine gore o sinif entity'sini getir.
                var mapGrade = _mapper.Map<GradeListDto>(grade);
                foreach (var user in users)
                {
                    if (mapGrade.Id == user.GradeId)
                    {
                        teacherStudents.Add(user);
                    }
                }
            }
            return teacherStudents;
        }
    }
}
