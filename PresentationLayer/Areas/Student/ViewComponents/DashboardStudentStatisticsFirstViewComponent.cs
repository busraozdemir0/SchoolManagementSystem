using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.ViewComponents
{
    public class DashboardStudentStatisticsFirstViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonService _lessonService;
        private readonly IAnnouncementService _announcementService;
		private readonly IMessageService _messageService;

		public DashboardStudentStatisticsFirstViewComponent(IUnitOfWork unitOfWork, IAnnouncementService announcementService, ILessonService lessonService, IMessageService messageService)
		{
			_unitOfWork = unitOfWork;
			_announcementService = announcementService;
			_lessonService = lessonService;
			_messageService = messageService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var lessons = await _lessonService.GetListAsync(); // Tum dersler lessons listesinde.
            var lessonsStudent = await _lessonService.TLessonsInTheStudent(lessons); // lessons listesi gonderilerek giris yapan ogrenci kullanicisinin dersleri listeleniyor. 
            ViewBag.LessonCount = lessonsStudent.Count();

            var announcement = await _announcementService.TStudentAnnouncementListAsync();
            ViewBag.AnnouncementCount=announcement.Count();

			// Giris yapan kisiye ait gelen mesajlardan okunmayanlarin kac adet oldugu bilgisi
			var inboxUnreadMessages = await _messageService.TGetUnreadMessagesByLoginUser();
			ViewBag.MessageCount = inboxUnreadMessages.Count();

			return View();
        }
    }
}
