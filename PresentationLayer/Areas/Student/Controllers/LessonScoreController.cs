using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.LessonScores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = RoleConsts.Student)]
    public class LessonScoreController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonScoreService _lessonScoreService;
        private readonly IMapper _mapper;

        public LessonScoreController(IAboutService aboutService, ILessonScoreService lessonScoreService, IMapper mapper)
        {
            _aboutService = aboutService;
            _lessonScoreService = lessonScoreService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScores = await _lessonScoreService.TGetListLoginStudentLessonScore();
            var mapLessonScores = _mapper.Map<List<LessonScoreListDto>>(lessonScores);

            // Agirlikli ortalama hesabi icin ogrencinin bulundugu siniftaki derslerin haftalık ders saatleri toplaniyor
            // ve sonuc ViewBag ile view'a gonderiliyor.
            int totalLessonCredit = 0;
            foreach (var item in lessonScores) 
            {
                totalLessonCredit += item.Lesson.LessonCredit;
            }
            ViewBag.TotalLessonCredit = totalLessonCredit;

            return View(mapLessonScores);
        }
    }
}
