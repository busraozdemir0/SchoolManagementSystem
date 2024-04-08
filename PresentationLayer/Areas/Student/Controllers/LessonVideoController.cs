using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.LessonVideos;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    public class LessonVideoController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonVideoService _lessonVideoService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonVideoController(IAboutService aboutService, ILessonVideoService lessonVideoService, ILessonService lessonService, IMapper mapper)
        {
            _aboutService = aboutService;
            _lessonVideoService = lessonVideoService;
            _lessonService = lessonService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ListVideoByLesson(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            var lessonVideos = await _lessonVideoService.TGetAllVideosByLesson(lessonId); // Bulunan ders nesnesi ile o derse yuklenmis videolar.
            var mapLessonVideos = _mapper.Map<List<LessonVideoListDto>>(lessonVideos);

            var lesson = await _lessonService.TGetByGuidAsync(lessonId); // Gelen ders id'sine gore ders nesnesi bulunuyor
            ViewBag.LessonName = lesson.LessonName;
            return View(mapLessonVideos);
        }
    }
}
