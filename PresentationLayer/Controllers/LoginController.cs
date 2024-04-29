using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.Extensions;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAboutService _aboutService;
        private readonly IRoleService _roleService;

        public LoginController(IUserService userService, IAboutService aboutService, IRoleService roleService)
        {
            _userService = userService;
            _aboutService = aboutService;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(userLoginDto);
                if (result is null)
                {
                    ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlıştır.");
                    return View();
                }
                else if (result.Succeeded || result is not null)
                {
                    var loginUserId = _userService.GetUserIdByUserName(userLoginDto.UserName);
                    AppRole userRole = await _roleService.TFindByUserRoleAsync(loginUserId); // Giren kisinin rolu

                    if (userRole.Name == RoleConsts.Admin) // Giren kisinin rol adi Admin'e esit ise Admin paneline yonlendirilecek
                        return RedirectToAction("Dashboard", "Home", new { Area = "Admin" });

                    else if (userRole.Name == RoleConsts.Teacher) // Giren kisinin rol adi Teacher'e esit ise Teacher paneline yonlendirilecek
                        return RedirectToAction("Index", "Home", new { Area = "Teacher" });

                    else if (userRole.Name == RoleConsts.Student) // Giren kisinin rol adi Student'e esit ise Student paneline yonlendirilecek
                        return RedirectToAction("Index", "Home", new { Area = "Student" });

                    else if (userRole.Name == RoleConsts.User) // Giren kisinin rol adi User'e esit ise Ana sayfada kalacak
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlıştır.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlıştır.");
                return View();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutUserAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AccessDenied()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            return View();
        }
    }
}
