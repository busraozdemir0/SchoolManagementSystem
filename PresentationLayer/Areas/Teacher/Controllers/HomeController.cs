using DataAccessLayer.Extensions;
using DataAccessLayer.Helpers.Search;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        private readonly ISearchProcess _searchProcess;
        private readonly IToastNotification _toast;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public HomeController(ISearchProcess searchProcess, IToastNotification toast, IHttpContextAccessor httpContextAccessor)
        {
            _searchProcess = searchProcess;
            _toast = toast;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string keyword, int page = 1)
        {
            ViewBag.Keyword = keyword;
            ViewBag.UserId = _user.GetLoggedInUserId();

            if (keyword == null)
            {
                _toast.AddErrorToastMessage("Aradığınız ifadeye uygun sonuç bulunamadı.", new ToastrOptions { Title = "Başarısız!" });
                return View();
            }

			else if (keyword.ToLower().Contains("öğrenci"))
				return RedirectToAction("Index", "Student", new { Area = "Teacher" });

            else if (keyword.ToLower().Contains("ayar") || keyword.ToLower().Contains("profil"))
                return RedirectToAction("Update", "Profile", new { Area = "Teacher" });

            else if (keyword.ToLower().Contains("duyuru") || keyword.ToLower().Contains("duyuru yap"))
                return RedirectToAction("Index", "Announcement", new { Area = "Teacher" });


            else
            {
                var result = await _searchProcess.SearchAsync(keyword, page);
                return View(result);
            }
        }
    }
}
