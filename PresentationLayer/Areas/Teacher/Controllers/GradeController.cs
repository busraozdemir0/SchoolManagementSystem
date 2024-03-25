using AutoMapper;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;


namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IUserService _userService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GradeController(IGradeService gradeService, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork, ILessonService lessonService)
        {
            _gradeService = gradeService;
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _lessonService = lessonService;

        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.TGetAllTeacherLessonsAsync(); // Login olan ogretmenin verdigi dersler listeleniyor.
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);

            HashSet<GradeListDto> teacherGrades = new(); // Login olan ogretmenin girdigi siniflarin tutulacagi liste. (HashSet yapisi tekrarsiz veri tutmasini saglayacak)
                                                         // İlgili dto'da IEquatable<GradeListDto> arayuzu implemente edildi ve ilgili metotlarin ici dolduruldu.

            foreach (var lesson in mapLessons)
            {
                var grade = await _gradeService.TGetGradeByIdAsync(lesson.GradeId); // Dersin ait oldugu sinifin id'sine gore o sinif entity'sini getir.
                var mapGrade = _mapper.Map<GradeListDto>(grade);

                teacherGrades.Add(mapGrade); // Map'lenen sinifi listeye ekle
            }
            return View(teacherGrades);
        }
        public async Task<IActionResult> GetAllStudentsWithGrade(int gradeId) // Gelen sinif id'sine gore o sinifta bulunan ogrencileri listeleyecek
        {
            ViewBag.GradeId = gradeId;

            var users = await _userService.TGetAllUsersWithRoleAsync();
            var mapStudents = _mapper.Map<List<UserListDto>>(users);

            return View(mapStudents);

        }
    }
}
