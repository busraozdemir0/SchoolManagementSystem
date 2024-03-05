using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class DashboardStatistics4ViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardStatistics4ViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalGradeCount = await _unitOfWork.GetRepository<Grade>().CountAsync(x => !x.IsDeleted);
            ViewBag.TotalGradeCount = totalGradeCount;

            var totalReportCount = await _unitOfWork.GetRepository<Report>().CountAsync(x => !x.IsDeleted);
            ViewBag.TotalReportCount = totalReportCount;

            return View();
        }
    }
}
