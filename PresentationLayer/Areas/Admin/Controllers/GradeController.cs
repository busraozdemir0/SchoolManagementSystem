using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Roles;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class GradeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IGradeService _gradeService;
        private readonly IUserService _userService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IValidator<Grade> _validator;
        private readonly IToastNotification _toast;

        public GradeController(IGradeService gradeService, IMapper mapper, IValidator<Grade> validator, IToastNotification toast, IUserService userService, ILessonService lessonService, IAboutService aboutService)
        {
            _gradeService = gradeService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _userService = userService;
            _lessonService = lessonService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grades = await _gradeService.GetListAsync();
            var mapGrades = _mapper.Map<List<GradeListDto>>(grades);
            return View(mapGrades);
        }
        public async Task<IActionResult> DeletedGrades()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grades = await _gradeService.GetDeletedListAsync();
            var mapGrades = _mapper.Map<List<GradeListDto>>(grades);
            return View(mapGrades);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(GradeAddDto gradeAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapGrade = _mapper.Map<Grade>(gradeAddDto);
            var result = await _validator.ValidateAsync(mapGrade);

            if (result.IsValid)
            {
                var message = await _gradeService.TIsThereTheSameGradeName(mapGrade.Name); // Ayni sinif adi var mi diye kontrol ediliyor.
                if (message is not null) // Eger null deger donmuyorsa ayni sinif adi vardir. Bu sebepten view tarafinda uyari mesaji verdiriyoruz.
                    ViewData["ErrorMessage"] = message;

                else // Eger null donuyorsa ayni sinif adina sahip deger yoktur bu yuzden ekleme islemleri gerceklestirilir.
                {
                    await _gradeService.TAddAsync(mapGrade);

                    _toast.AddSuccessToastMessage(Messages.Grade.Add(gradeAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "Grade", new { Area = "Admin" });
                }
            }
            else
            {
                _toast.AddErrorToastMessage("Sınıf eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int gradeId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            var mapGrade = _mapper.Map<GradeUpdateDto>(grade);
            return View(mapGrade);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GradeUpdateDto gradeUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapGrade = _mapper.Map<Grade>(gradeUpdateDto);
            var result = await _validator.ValidateAsync(mapGrade);

            if (result.IsValid)
            {
                await _gradeService.TUpdateAsync(mapGrade);
                _toast.AddSuccessToastMessage(Messages.Grade.Update(gradeUpdateDto.Name), new ToastrOptions { Title = "Başarılı!" });
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
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var gradeName = await _gradeService.TSafeDeleteGradeAsync(gradeId);
            _toast.AddSuccessToastMessage(Messages.Grade.Delete(gradeName), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Grade", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(int gradeId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var gradeName = await _gradeService.TUndoDeleteGradeAsync(gradeId);
            _toast.AddSuccessToastMessage(Messages.Grade.UndoDelete(gradeName), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedGrades", "Grade", new { Area = "Admin" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(int gradeId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            await _gradeService.TDeleteAsync(grade);
            _toast.AddSuccessToastMessage("Sınıf tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedGrades", "Grade", new { Area = "Admin" });
        }

        public async Task<IActionResult> GetAllStudentsWithGrade(int gradeId) // Gelen sinif id'sine gore o sinifta bulunan ogrencileri listeleyecek
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            ViewBag.GradeId = gradeId;
            ViewBag.GradeName = grade.Name;

            var users = await _userService.TGetAllUsersWithRoleAsync();
            var mapStudents = _mapper.Map<List<UserListDto>>(users);

            return View(mapStudents);
        }

        public async Task<IActionResult> GetAllLessonsWithGrade(int gradeId) // Gelen sinif id'sine gore o sinifta bulunan dersleri listeleyecek
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            ViewBag.GradeId = gradeId;
            ViewBag.GradeName = grade.Name;

            var lessons = await _lessonService.GetListAsync();
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);

            return View(mapLessons);

        }
        public async Task<IActionResult> StudentExcelReport(int gradeId) // O sinifta olan ogrenciler listesini excel formatinda indirmek icin
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var students = await _userService.TGetAllStudentsWithRoleAsync(); // Ogrenciler listesi
            HashSet<UserListDto> studentsInClasses = new();

            foreach (var item in students)
            {
                if (item.GradeId == gradeId) // Ogrenci gelen sinif id'si ile eslesiyorsa listeye ekle
                    studentsInClasses.Add(item);
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
                foreach (var item in studentsInClasses)
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

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] GradeAddDto gradeAddDto) // Ajax ile sinif ekleme islemi
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapGrade = _mapper.Map<Grade>(gradeAddDto);
            var validation = await _validator.ValidateAsync(mapGrade);

            if (validation.IsValid)
            {
                await _gradeService.TAddAsync(mapGrade);
                _toast.AddSuccessToastMessage(Messages.Grade.Add(gradeAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
                return Json(Messages.Grade.Add(gradeAddDto.Name));
            }
            else
            {
                validation.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Sınıf eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                return Json(validation.Errors.First().ErrorMessage);
            }
        }
    }
}
