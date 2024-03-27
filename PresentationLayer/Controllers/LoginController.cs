using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAboutService _aboutService;

        public LoginController(IUserService userService, IAboutService aboutService)
        {
            _userService = userService;
            _aboutService = aboutService;
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
                    return RedirectToAction("Dashboard", "Home", new { Area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlıştır.");
                    return View();
                }
            }else
            {
                ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlıştır.");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutUserAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
