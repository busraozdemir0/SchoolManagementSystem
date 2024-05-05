﻿using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Context;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using DataAccessLayer.Consts;
using PresentationLayer.ResultMessages;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class UserController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUser> _validator;
        private readonly IToastNotification _toast;

        public UserController(IUserService userService, IMapper mapper, IRoleService roleService, IValidator<AppUser> validator, IToastNotification toast, IGradeService gradeService, IAboutService aboutService)
        {
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;
            _validator = validator;
            _toast = toast;
            _gradeService = gradeService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var users = await _userService.TGetAllUsersWithRoleAsync(); // Tum kullanicilar
            return View(users);
        }
        public async Task<IActionResult> GetAllTeachers()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var users = await _userService.TGetAllTeachersWithRoleAsync(); // Ogretmenler listesi
            return View(users);
        }
        public async Task<IActionResult> GetAllStudents()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var users = await _userService.TGetAllStudentsWithRoleAsync(); // Ogrenciler listesi
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var roles = await _roleService.TGetAllRolesAsync();

            var grades = await _gradeService.GetListAsync();

            return View(new UserAddDto { Roles = roles, Grades = grades });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(UserAddDto userAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grades = await _gradeService.GetListAsync();
            return View(new UserAddDto { Grades = grades });
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(UserAddDto userAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
            return View(); // User'ı bulamazsa NotFound donecek.
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeacher(Guid userId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var user = await _userService.TGetAppUserByIdAsync(userId);

            var userRoleId = await _roleService.TGetByIdRoleAsync(RoleConsts.Teacher); // Teacher rolu      

            var mapUserUpdateDto = _mapper.Map<UserUpdateDto>(user);
            mapUserUpdateDto.RoleId = userRoleId;
            return View(mapUserUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeacher(UserUpdateDto userUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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
        // Kullaniciyi tamamen silme pasifleştiriliyor
        //public async Task<IActionResult> Delete(Guid userId)
        //{
        //    ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

        //    // Identity'nin ondelete metodlarında eger bir kullanici silinirse kullaniciya bagli olan roller de silindigi icin ayriyetten rol silme islemine gerek kalmamaktadir.
        //    var result = await _userService.TDeleteUserAsync(userId); // Buradan hem identityResult hem de kullanici adi donecek.
        //    if (result.identityResult.Succeeded)
        //    {
        //        _toast.AddSuccessToastMessage(Messages.User.Delete(result.userName), new ToastrOptions { Title = "Başarılı!" });
        //        return RedirectToAction("Index", "User", new { Area = "Admin" });
        //    }
        //    else
        //    {
        //        result.identityResult.AddToIdentityModelState(this.ModelState);
        //        _toast.AddErrorToastMessage("Kullanıcı silinirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
        //    }
        //    return View();
        //}
        public async Task<IActionResult> SafeDelete(Guid userId) // Kullaniciyi tamamen silmek yerine SafeDelete yontemi kullanilmaktadir.
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var result = await _userService.TSafeDeleteUserAsync(userId); // Buradan hem identityResult hem de kullanici adi donecek.
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
        public async Task<IActionResult> UndoDelete(Guid userId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var result = await _userService.TUndoDeleteUserAsync(userId);
            _toast.AddSuccessToastMessage(Messages.User.UndoDelete(result), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("GetAllDeletedUsers", "User", new { Area = "Admin" });
        }
        public async Task<IActionResult> GetAllDeletedUsers()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var deletedUsers = await _userService.TGetAllDeletedUserAsync();
            return View(deletedUsers);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var profile = await _userService.TGetUserProfileAsync();
            ViewBag.DefaultProfileImage = "user-avatar-profile.png"; // Eger hic profil resmi yuklenmemisse varsayilan resim gosterilecek.

            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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

        public async Task<IActionResult> StudentExcelReport() // Ogrenciler listesini excel formatinda indirmek icin
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var students = await _userService.TGetAllStudentsWithRoleAsync(); // Ogrenciler listesi

            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Öğrenci Listesi");
                workSheet.Cell(1, 1).Value = "Öğrenci Numarası";
                workSheet.Cell(1, 2).Value = "Adı";
                workSheet.Cell(1, 3).Value = "Soyadı";
                workSheet.Cell(1, 4).Value = "Cinsiyeti";
                workSheet.Cell(1, 5).Value = "Sınıfı";
                workSheet.Cell(1, 6).Value = "Telefon Numarası";
                workSheet.Cell(1, 7).Value = "E-Mail";

                int rowCount = 2;
                foreach (var item in students)
                {
                    workSheet.Cell(rowCount, 1).Value = item.StudentNo;
                    workSheet.Cell(rowCount, 2).Value = item.Name;
                    workSheet.Cell(rowCount, 3).Value = item.Surname;
                    workSheet.Cell(rowCount, 4).Value = item.Gender;
                    workSheet.Cell(rowCount, 5).Value = item.Grade.Name;
                    workSheet.Cell(rowCount, 6).Value = item.PhoneNumber;
                    workSheet.Cell(rowCount, 7).Value = item.Email;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StudentsList.xlsx");
                }
            }
        }
    }
}
