using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    public class LessonDocumentController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonDocumentService _lessonDocumentService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonDocumentController(IAboutService aboutService, IMapper mapper, ILessonDocumentService lessonDocumentService, ILessonService lessonService)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _lessonDocumentService = lessonDocumentService;
            _lessonService = lessonService;
        }

        public async Task<IActionResult> ListDocumentByLesson(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            var lessonDocuments = await _lessonDocumentService.TGetAllDocumentsByLesson(lessonId); // Bulunan ders nesnesi ile o derse yuklenmis dokumanlar.
            var mapLessonDocuments = _mapper.Map<List<LessonDocumentListDto>>(lessonDocuments);
            
            var lesson = await _lessonService.TGetByGuidAsync(lessonId); // Gelen ders id'sine gore ders nesnesi bulunuyor
            ViewBag.LessonName = lesson.LessonName;

            return View(mapLessonDocuments);
        }
    }
}
