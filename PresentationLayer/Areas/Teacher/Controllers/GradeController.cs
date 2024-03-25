using AutoMapper;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Consts;
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
            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            ViewBag.GradeName=grade.Name;
            ViewBag.GradeId = gradeId;

            var users = await _userService.TGetAllUsersWithRoleAsync();
            var mapStudents = _mapper.Map<List<UserListDto>>(users);

            return View(mapStudents);

        }

        public async Task<IActionResult> StudentExcelReport(int gradeId) // Ogrenciler listesini excel formatinda indirmek icin
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            var studentInClasses = await _userService.TStudentInClasListAsync(users); // Giren ogretmenin ders verdigi siniflarda bulunan ogrenciler listesi
            HashSet<UserListDto> students = new();

            foreach(var item in studentInClasses)
            {
                if (item.GradeId == gradeId && item.Role==RoleConsts.Student) // Eger kullanici ogrenci rolundeyse ve gelen sinif id'si ile eslesiyorsa listeye ekle
                    students.Add(item);              
            }

            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);

            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add(grade.Name+" Öğrenci Listesi");
                workSheet.Cell(1, 1).Value = "Öğrenci Numarası";
                workSheet.Cell(1, 2).Value = "Adı";
                workSheet.Cell(1, 3).Value = "Soyadı";
                workSheet.Cell(1, 4).Value = "Cinsiyeti";
                workSheet.Cell(1, 5).Value = "Sınıfı";
                workSheet.Cell(1, 6).Value = "Telefon Numarası";
                workSheet.Cell(1, 7).Value = "E-Mail";

                int rowCount = 2;
                foreach (var item in students)
                {
                    workSheet.Cell(rowCount, 1).Value = item.StudentNo;
                    workSheet.Cell(rowCount, 2).Value = item.Name;
                    workSheet.Cell(rowCount, 3).Value = item.Surname;
                    workSheet.Cell(rowCount, 4).Value = item.Gender;
                    workSheet.Cell(rowCount, 5).Value = item.Grade.Name;
                    workSheet.Cell(rowCount, 6).Value = item.PhoneNumber;
                    workSheet.Cell(rowCount, 7).Value = item.Email;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", grade.Name + "StudentsList.xlsx");
                }
            }
        }

    }
}
