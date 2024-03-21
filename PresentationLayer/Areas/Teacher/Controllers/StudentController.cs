using BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class StudentController : Controller
    {
        private readonly IUserService _userService;

        public StudentController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            return View(users);
        }
    }
}
