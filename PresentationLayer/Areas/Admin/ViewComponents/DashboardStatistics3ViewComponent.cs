using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class DashboardStatistics3ViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardStatistics3ViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalUserCount = await _unitOfWork.GetRepository<AppUser>().CountAsync();
            ViewBag.TotalUserCount = totalUserCount;

            var totalReportCount = await _unitOfWork.GetRepository<Report>().CountAsync(x=>!x.IsDeleted);
            ViewBag.TotalReportCount = totalReportCount;

            var totalAnnouncementCount = await _unitOfWork.GetRepository<Announcement>().CountAsync(x => !x.IsDeleted);
            ViewBag.TotalAnnouncementCount = totalAnnouncementCount;

            var totalContactCount = await _unitOfWork.GetRepository<Contact>().CountAsync(x => !x.IsDeleted);
            ViewBag.TotalContactCount = totalContactCount;

            var totalNewsLetterCount = await _unitOfWork.GetRepository<NewsLetter>().CountAsync(x => !x.IsDeleted);
            ViewBag.TotalNewsLetterCount = totalNewsLetterCount;

            var totalRoleCount = await _unitOfWork.GetRepository<AppRole>().CountAsync();
            ViewBag.TotalRoleCount = totalRoleCount;

            return View();
        }
    }
}
