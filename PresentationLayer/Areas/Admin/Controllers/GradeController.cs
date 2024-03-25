using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;
using static PresentationLayer.ResultMessages.Messages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IUserService _userService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IValidator<Grade> _validator;
        private readonly IToastNotification _toast;

        public GradeController(IGradeService gradeService, IMapper mapper, IValidator<Grade> validator, IToastNotification toast, IUserService userService, ILessonService lessonService)
        {
            _gradeService = gradeService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _userService = userService;
            _lessonService = lessonService;
        }

        public async Task<IActionResult> Index()
        {
            var grades=await _gradeService.GetListAsync();
            var mapGrades=_mapper.Map<List<GradeListDto>>(grades);
            return View(mapGrades);
        }
        public async Task<IActionResult> DeletedGrades()
        {
            var grades = await _gradeService.GetDeletedListAsync();
            var mapGrades = _mapper.Map<List<GradeListDto>>(grades);
            return View(mapGrades);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(GradeAddDto gradeAddDto)
        {
            var mapGrade = _mapper.Map<Grade>(gradeAddDto);
            var result=await _validator.ValidateAsync(mapGrade);

            if (result.IsValid)
            {
                await _gradeService.TAddAsync(mapGrade);
                _toast.AddSuccessToastMessage(gradeAddDto.Name + " adlı sınıf başarıyla eklendi.", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Grade", new { Area = "Admin" });
            }
            else
            {
                _toast.AddSuccessToastMessage(gradeAddDto.Name + " adlı sınıf eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int gradeId)
        {
            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            var mapGrade=_mapper.Map<GradeUpdateDto>(grade);
            return View(mapGrade);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GradeUpdateDto gradeUpdateDto)
        {
            var mapGrade = _mapper.Map<Grade>(gradeUpdateDto);
            var result = await _validator.ValidateAsync(mapGrade);

            if (result.IsValid)
            {
                await _gradeService.TUpdateAsync(mapGrade);
                _toast.AddSuccessToastMessage(gradeUpdateDto.Name + " adlı sınıf başarıyla güncellendi.", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Grade", new { Area = "Admin" });
            }
            else
            {
                _toast.AddSuccessToastMessage(gradeUpdateDto.Name + " adlı sınıf güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            return View();
        }
        public async Task<IActionResult> SafeDelete(int gradeId)
        {
            var gradeName=await _gradeService.TSafeDeleteGradeAsync(gradeId);
            _toast.AddSuccessToastMessage(gradeName+" adlı sınıf başarıyla silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Grade", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(int gradeId)
        {
            var gradeName = await _gradeService.TUndoDeleteGradeAsync(gradeId);
            _toast.AddSuccessToastMessage(gradeName + " adlı sınıf başarıyla geri alındı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedGrades", "Grade", new { Area = "Admin" });
        }
		public async Task<IActionResult> HardDelete(int gradeId)
		{
            var grade=await _gradeService.TGetGradeByIdAsync(gradeId);
			await _gradeService.TDeleteAsync(grade);
			_toast.AddSuccessToastMessage("Sınıf tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
			return RedirectToAction("DeletedGrades", "Grade", new { Area = "Admin" });
		}

        public async Task<IActionResult> GetAllStudentsWithGrade(int gradeId) // Gelen sinif id'sine gore o sinifta bulunan ogrencileri listeleyecek
        {
            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            ViewBag.GradeId = gradeId;
            ViewBag.GradeName = grade.Name;

            var users = await _userService.TGetAllUsersWithRoleAsync();
            var mapStudents = _mapper.Map<List<UserListDto>>(users);

            return View(mapStudents);
        }

        public async Task<IActionResult> GetAllLessonsWithGrade(int gradeId) // Gelen sinif id'sine gore o sinifta bulunan dersleri listeleyecek
        {
            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            ViewBag.GradeId = gradeId;
            ViewBag.GradeName = grade.Name;

            var lessons = await _lessonService.GetListAsync();
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);

            return View(mapLessons);

        }
        public async Task<IActionResult> StudentExcelReport(int gradeId) // Ogrenciler listesini excel formatinda indirmek icin
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            var studentInClasses = await _userService.TStudentInClasListAsync(users); // Giren ogretmenin ders verdigi siniflarda bulunan ogrenciler listesi
            HashSet<UserListDto> students = new();

            foreach (var item in studentInClasses)
            {
                if (item.GradeId == gradeId && item.Role == RoleConsts.Student) // Eger kullanici ogrenci rolundeyse ve gelen sinif id'si ile eslesiyorsa listeye ekle
                    students.Add(item);
            }

            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);

            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add(grade.Name + " Öğrenci Listesi");
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
