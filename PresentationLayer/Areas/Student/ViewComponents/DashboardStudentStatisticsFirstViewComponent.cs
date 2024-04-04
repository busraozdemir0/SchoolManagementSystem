using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.ViewComponents
{
    public class DashboardStudentStatisticsFirstViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonService _lessonService;
        private readonly IAnnouncementService _announcementService;

        public DashboardStudentStatisticsFirstViewComponent(IUnitOfWork unitOfWork, IAnnouncementService announcementService, ILessonService lessonService)
        {
            _unitOfWork = unitOfWork;
            _announcementService = announcementService;
            _lessonService = lessonService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lessons = await _lessonService.TGetAllTeacherLessonsAsync();
            ViewBag.LessonCount = lessons.Count();

            var announcementCount = await _announcementService.TTeacherAnnouncementListAsync();
            ViewBag.AnnouncementCount=announcementCount.Count();

            ViewBag.MessageCount = 12; // Toplam mesaj sayisi listelenecek

            return View();
        }
    }
}
