using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.Helpers.Search;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Search;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;
using X.PagedList;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        private readonly ISearchProcess _searchProcess;
        private readonly IAboutService _aboutService;
        private readonly IToastNotification _toast;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public HomeController(ISearchProcess searchProcess, IAboutService aboutService, IToastNotification toast, IHttpContextAccessor httpContextAccessor)
        {
            _searchProcess = searchProcess;
            _aboutService = aboutService;
            _toast = toast;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
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
            ViewBag.UserId = _user.GetLoggedInUserId();

            if (keyword == null)
            {
                _toast.AddErrorToastMessage("Aradığınız ifadeye uygun sonuç bulunamadı.", new ToastrOptions { Title = "Başarısız!" });
                return View();
            }

            else if (keyword.ToLower().Contains("ayar") || keyword.ToLower().Contains("profil"))
                return RedirectToAction("Update", "Profile", new { Area = "Teacher" });

            else if ( keyword.ToLower().Contains("duyuru yap") || keyword.ToLower().Contains("öğrenci duyuruları"))
                return RedirectToAction("StudentAnnouncements", "Announcement", new { Area = "Teacher" });


            else
            {
                var result = await _searchProcess.SearchTeacherAsync(keyword, page);
                return View(result);
            }
        }
    }
}
