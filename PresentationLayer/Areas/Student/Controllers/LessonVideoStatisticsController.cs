using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = RoleConsts.Student)]
    public class LessonVideoStatisticsController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonVideoService _lessonVideoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LessonVideoStatisticsController(IAboutService aboutService, ILessonVideoService lessonVideoService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _aboutService = aboutService;
            _lessonVideoService = lessonVideoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();


            var unwatchedLessonVideo = await _lessonVideoService.TUnwatchedVideosByLoginStudent();
            var mapUnwatchedLessonVideo = _mapper.Map<List<LessonVideoListDto>>(unwatchedLessonVideo);
            return View(mapUnwatchedLessonVideo);
        }

        public async Task<IActionResult> LessonVideoChart()
        {
            var lessonVideosLoginStudent = await _lessonVideoService.TLessonVideosByLoginStudent(); // Giris yapan ogrencinin derslerine yuklenmis tum videolar
            var unwatchedLessonVideo = await _lessonVideoService.TUnwatchedVideosByLoginStudent(); // Giris yapan ogrencinin derslerine yuklenen videolardan izlemedigi videolar

            var watchedLessonVideoCount = lessonVideosLoginStudent.Count - unwatchedLessonVideo.Count;

            return Json(new { watchedCount = watchedLessonVideoCount, totalVideos = lessonVideosLoginStudent.Count });
        }
    }
}
