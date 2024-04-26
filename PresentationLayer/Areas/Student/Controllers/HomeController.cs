using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.Helpers.Search;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
		private readonly IAboutService _aboutService;
        private readonly ISearchProcess _searchProcess;
        private readonly IToastNotification _toast;

        public HomeController(IAboutService aboutService, IToastNotification toast, ISearchProcess searchProcess)
        {
            _aboutService = aboutService;
            _toast = toast;
            _searchProcess = searchProcess;
        }

        public async Task<IActionResult> Index()
        {
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
			return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string keyword, int page = 1)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            ViewBag.Keyword = keyword;

            if (keyword == null)
            {
                _toast.AddErrorToastMessage("Aradığınız ifadeye uygun sonuç bulunamadı.", new ToastrOptions { Title = "Başarısız!" });
                return View();
            }

            else if (keyword.ToLower().Contains("ayar") || keyword.ToLower().Contains("profil"))
                return RedirectToAction("Update", "Profile", new { Area = "Student" });

            else if (keyword.ToLower().Contains("not") || keyword.ToLower().Contains("sistem") || keyword.ToLower().Contains("puan"))
                return RedirectToAction("Index", "LessonScore", new { Area = "Student" });

            else if (keyword.ToLower().Contains("mesaj") || keyword.ToLower().Contains("mail"))
                return RedirectToAction("InBox", "Message", new { Area = "Student" });

            else
            {
                var result = await _searchProcess.SearchStudentAsync(keyword, page);
                return View(result);
            }
        }
    }
}
