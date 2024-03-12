using BusinessLayer.Services.Abstract;
using DataAccessLayer.Helpers.Search;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using X.PagedList;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IToastNotification _toast;
        private readonly ISearchProcess _searchProcess;

        public HomeController(IReportService reportService, IToastNotification toast, ISearchProcess searchProcess)
        {
            _reportService = reportService;
            _toast = toast;
            _searchProcess = searchProcess;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string keyword, int page=1)
        {
            ViewBag.Keyword = keyword;

            if (keyword == null)
            {
                _toast.AddErrorToastMessage("Aradığınız ifadeye uygun sonuç bulunamadı.", new ToastrOptions { Title = "Başarısız!" });
                return View();
            }

            else if (keyword.ToLower().Contains("hakkımızda") || keyword.ToLower().Contains("misyon") || keyword.ToLower().Contains("vizyon"))
                return RedirectToAction("Update", "About", new { Area = "Admin" });

            else if (keyword.ToLower().Contains("adres") || keyword.ToLower().Contains("konum") || keyword.ToLower().Contains("harita"))
                return RedirectToAction("Update", "Address", new { Area = "Admin" });

            else if (keyword.ToLower().Contains("abone") || keyword.ToLower().Contains("haber bülteni"))
                return RedirectToAction("Index", "NewsLetter", new { Area = "Admin" });

            else
            {
                var result = await _searchProcess.SearchAsync(keyword,page);
                return View(result);
            }
        }
    }
}
