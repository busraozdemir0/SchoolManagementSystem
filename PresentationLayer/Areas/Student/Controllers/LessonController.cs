using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = RoleConsts.Student)]
    public class LessonController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(IAboutService aboutService, ILessonService lessonService, IMapper mapper)
        {
            _aboutService = aboutService;
            _lessonService = lessonService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessons = await _lessonService.GetListAsync(); // Tum dersler lessons listesinde.
            var lessonsStudent = await _lessonService.TLessonsInTheStudent(lessons); // lessons listesi gonderilerek giris yapan ogrenci kullanicisinin dersleri listeleniyor. 
            return View(lessonsStudent);
        }
    }
}
