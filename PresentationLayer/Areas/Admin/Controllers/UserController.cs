using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Context;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.Consts;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUser> _validator;
        private readonly IToastNotification _toast;

        public UserController(IUserService userService, IMapper mapper, IRoleService roleService, IValidator<AppUser> validator, IToastNotification toast, IGradeService gradeService)
        {
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;
            _validator = validator;
            _toast = toast;
            _gradeService = gradeService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            return View(users);
        }
        public async Task<IActionResult> GetAllTeachers()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            return View(users);
        }
        public async Task<IActionResult> GetAllStudents()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleService.TGetAllRolesAsync();

            var grades = await _gradeService.GetListAsync();
            return View(new UserAddDto { Roles = roles, Grades = grades });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(mapUser);

            var roles = await _roleService.TGetAllRolesAsync(); // Tum roller
            var grades = await _gradeService.GetListAsync();

            if (ModelState.IsValid)
            {
                var result = await _userService.TCreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    _toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    _toast.AddErrorToastMessage("Kullanıcı eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });

                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles, Grades = grades });
                }
            }
            return View(new UserAddDto { Roles = roles, Grades = grades });
        }
        [HttpGet]
        public async Task<IActionResult> AddTeacher()
        {
            var grades = await _gradeService.GetListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(mapUser);

            if (ModelState.IsValid)
            {
                var result = await _userService.TCreateTeacherAsync(userAddDto);
                if (result.Succeeded)
                {
                    _toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("GetAllTeachers", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    _toast.AddErrorToastMessage("Öğretmen eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });

                    validation.AddToModelState(this.ModelState);
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            var grades = await _gradeService.GetListAsync();
            return View(new UserAddDto { Grades = grades });
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(mapUser);

            var grades = await _gradeService.GetListAsync();

            if (ModelState.IsValid)
            {
                var result = await _userService.TCreateStudentAsync(userAddDto);
                if (result.Succeeded)
                {
                    _toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("GetAllStudents", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    _toast.AddErrorToastMessage("Öğrenci eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });

                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Grades = grades });
                }
            }
            return View(new UserAddDto { Grades = grades });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            ViewBag.IsStudent = false; // Ogrenci mi oldugu bilgisi en basta false olsun

            var user = await _userService.TGetAppUserByIdAsync(userId);
            var grades = await _gradeService.GetListAsync(); // Siniflar

            var userRole = await _userService.TGetUserRoleAsync(user); // Kullanicinin rolu
            var userRoleId = await _roleService.TGetByIdRoleAsync(userRole);

            var roles = await _roleService.TGetAllRolesAsync(); // Roller        

            var mapUserUpdateDto = _mapper.Map<UserUpdateDto>(user);
            mapUserUpdateDto.Roles = roles;
            mapUserUpdateDto.RoleId = userRoleId;

            mapUserUpdateDto.Grades = grades;

            if (userRole == RoleConsts.Student)
            {
                ViewBag.IsStudent = true; // Ogrenci mi bilgisi view'a yansitilmasi icin

                var gradeId = await _userService.TGetUserGradeIdAsync(user);

                mapUserUpdateDto.GradeId = gradeId;
            }
            return View(mapUserUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userService.TGetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null) // Eger boyle bir kullanici varsa
            {
                var roles = await _roleService.TGetAllRolesAsync();
                var grades = await _gradeService.GetListAsync(); // Siniflar

                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateDto, user); // Dto ile guncellenecek olan kullanici(user) birbirine esleniyor.
                                                                // Bu kod satiri aslinda asagidaki islemi yapmaktadir
                                                                //user.Name = userUpdateDto.Name;
                                                                //user.Name = userUpdateDto.Name;
                                                                //user.Email = userUpdateDto.Email;
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userService.TUpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            _toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            _toast.AddErrorToastMessage("Kullanıcı güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                            return View(new UserUpdateDto { Roles = roles, Grades = grades });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles, Grades = grades });
                    }
                }
            }
            return NotFound(); // User'ı bulamazsa NotFound donecek.
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeacher(Guid userId)
        {
            var user = await _userService.TGetAppUserByIdAsync(userId);

            var userRoleId = await _roleService.TGetByIdRoleAsync(RoleConsts.Teacher); // Teacher rolu      

            var mapUserUpdateDto = _mapper.Map<UserUpdateDto>(user);
            mapUserUpdateDto.RoleId = userRoleId;
            return View(mapUserUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeacher(UserUpdateDto userUpdateDto)
        {
            var user = await _userService.TGetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null) // Eger boyle bir kullanici varsa
            {
                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateDto, user);
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userService.TUpdateTeacherAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            _toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                            return RedirectToAction("GetAllTeachers", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            _toast.AddErrorToastMessage("Öğretmen güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                            return View();
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View();
                    }
                }
            }
            return NotFound(); // User'ı bulamazsa NotFound donecek.
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStudent(Guid userId)
        {
            var user = await _userService.TGetAppUserByIdAsync(userId);
            var grades = await _gradeService.GetListAsync(); // Siniflar

            var userRoleId = await _roleService.TGetByIdRoleAsync(RoleConsts.Student); // Student rolu       

            var mapUserUpdateDto = _mapper.Map<UserUpdateDto>(user);
            mapUserUpdateDto.RoleId = userRoleId;

            mapUserUpdateDto.Grades = grades;

            var gradeId = await _userService.TGetUserGradeIdAsync(user);
            mapUserUpdateDto.GradeId = gradeId;

            return View(mapUserUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(UserUpdateDto userUpdateDto)
        {
            var user = await _userService.TGetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null) // Eger boyle bir kullanici varsa
            {
                var grades = await _gradeService.GetListAsync(); // Siniflar

                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateDto, user); 
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userService.TUpdateStudentAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            _toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                            return RedirectToAction("GetAllStudents", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            _toast.AddErrorToastMessage("Öğrenci güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                            return View(new UserUpdateDto { Grades = grades });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Grades = grades });
                    }
                }
            }
            return NotFound(); // User'ı bulamazsa NotFound donecek.
        }

        public async Task<IActionResult> Delete(Guid userId)
        {
            // Identity'nin ondelete metodlarında eger bir kullanici silinirse kullaniciya bagli olan roller de silindigi icin ayriyetten rol silme islemine gerek kalmamaktadir.
            var result = await _userService.TDeleteUserAsync(userId); // Buradan hem identityResult hem de kullanici adi donecek.
            if (result.identityResult.Succeeded)
            {
                _toast.AddSuccessToastMessage(Messages.User.Delete(result.userName), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
                _toast.AddErrorToastMessage("Kullanıcı silinirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await _userService.TGetUserProfileAsync();
            ViewBag.DefaultProfileImage = "user-avatar-profile.png"; // Eger hic profil resmi yuklenmemisse varsayilan resim gosterilecek.

            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            var mapUser = _mapper.Map<AppUser>(userProfileDto);
            var validation = await _validator.ValidateAsync(mapUser);

            if (validation.IsValid)
            {
                var result = await _userService.TUserProfileUpdateAsync(userProfileDto);
                if (result)
                {
                    _toast.AddSuccessToastMessage("Profil güncelleme işlemi başarıyla tamamlandı.", new ToastrOptions { Title = "İşlem Başarılı!" });
                    return RedirectToAction("Profile", "User", new { Area = "Admin" });
                }
                else
                {
                    var profile = await _userService.TGetUserProfileAsync();

                    _toast.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı.", new ToastrOptions { Title = "İşlem Başarısız!" });
                    return View(profile);
                }
            }
            else
            {
                var profile = await _userService.TGetUserProfileAsync();
                ViewBag.DefaultProfileImage = "user-avatar-profile.png";

                validation.AddToModelState(this.ModelState);
                return View(profile);
            }

        }
    }
}
