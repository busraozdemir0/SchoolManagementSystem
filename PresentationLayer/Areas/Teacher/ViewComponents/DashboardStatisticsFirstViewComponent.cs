using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Teacher.ViewComponents
{
    public class DashboardStatisticsFirstViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonService _lessonService;
        private readonly IAnnouncementService _announcementService;
        private readonly IMessageService _messageService;

        public DashboardStatisticsFirstViewComponent(IUnitOfWork unitOfWork, IAnnouncementService announcementService, ILessonService lessonService, IMessageService messageService)
        {
            _unitOfWork = unitOfWork;
            _announcementService = announcementService;
            _lessonService = lessonService;
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lessons = await _lessonService.TGetAllTeacherLessonsAsync();
            ViewBag.LessonCount = lessons.Count();

            var announcementCount = await _announcementService.TTeacherAnnouncementListAsync();
            ViewBag.AnnouncementCount=announcementCount.Count();

            // Giris yapan kisiye ait gelen mesajlardan okunmayanlarin kac adet oldugu bilgisi
            var inboxUnreadMessages = await _messageService.TGetUnreadMessagesByLoginUser();
            ViewBag.MessageCount = inboxUnreadMessages.Count();

            return View();
        }
    }
}
