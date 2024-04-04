using BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
		private readonly IAboutService _aboutService;

		public HomeController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public async Task<IActionResult> Index()
        {
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
			return View();
        }
    }
}
