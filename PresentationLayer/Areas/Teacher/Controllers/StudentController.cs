using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class StudentController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILessonService _lessonService;
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;

        public StudentController(IUserService userService, ILessonService lessonService, IMapper mapper, IGradeService gradeService)
        {
            _userService = userService;
            _lessonService = lessonService;
            _mapper = mapper;
            _gradeService = gradeService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            //return View(users);

            var lessons = await _lessonService.TGetAllTeacherLessonsAsync(); // Login olan ogretmenin verdigi dersler listeleniyor.
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);

            HashSet<UserListDto> teacherStudents = new(); // Login olan ogretmenin girdigi siniflarin tutulacagi liste. (HashSet yapisi tekrarsiz veri tutmasini saglayacak)
                                                          // İlgili dto'da IEquatable<GradeListDto> arayuzu implemente edildi ve ilgili metotlarin ici dolduruldu.

            foreach (var lesson in mapLessons)
            {
                var grade = await _gradeService.TGetGradeByIdAsync(lesson.GradeId); // Dersin ait oldugu sinifin id'sine gore o sinif entity'sini getir.
                var mapGrade = _mapper.Map<GradeListDto>(grade);
                foreach (var user in users)
                {
                    if(mapGrade.Id == user.GradeId)
                    {
                        teacherStudents.Add(user);
                    }
                }
            }
            return View(teacherStudents);
        }
    }
}
