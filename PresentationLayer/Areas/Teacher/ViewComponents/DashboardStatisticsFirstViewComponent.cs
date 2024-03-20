using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Teacher.ViewComponents
{
    public class DashboardStatisticsFirstViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IAnnouncementService _announcementService;

        public DashboardStatisticsFirstViewComponent(IUnitOfWork unitOfWork, IUserService userService, IAnnouncementService announcementService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _announcementService = announcementService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            var studentCount=users.Count(x=>x.Role==RoleConsts.Student); // Student rolune sahip kullanicilari say
            ViewBag.StudentCount=studentCount;

            var announcementCount = await _announcementService.TTeacherAnnouncementListAsync();
            ViewBag.AnnouncementCount=announcementCount.Count();

            ViewBag.MessageCount = 12; // Toplam mesaj sayisi listelenecek

            return View();
        }
    }
}
