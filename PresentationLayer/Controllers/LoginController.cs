using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(userLoginDto);
                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Home", new { Area = "Admin" });
                }
                else // Giris basarili degilse mesaj dondurecek bir error ekliyoruz.
                {
                    ModelState.AddModelError("", "E-Posta veya şifreniz yanlıştır.");
                    return View(); // tekrar Login'i getir
                }
            }else
            {
                ModelState.AddModelError("", "E-Posta veya şifreniz yanlıştır.");
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
