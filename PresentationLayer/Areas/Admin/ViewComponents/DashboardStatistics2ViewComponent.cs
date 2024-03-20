using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Consts;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class DashboardStatistics2ViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public DashboardStatistics2ViewComponent(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _unitOfWork.GetRepository<AppUser>().GetAllAsync();

            int totalStudentCount = 0;
            foreach(var user in users)
            {
                var userRole = await _userService.TGetUserRoleAsync(user);

                if(userRole == RoleConsts.Student) 
                {
                    totalStudentCount++;
                }
            }
            ViewBag.TotalStudentCount = totalStudentCount;

            var reports=await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted);

            var sortedReports=reports.OrderByDescending(x => x.CreatedDate);
            var lastReport=sortedReports.First();
            ViewBag.LastReport = lastReport.Title;

            return View();
        }
    }
}
