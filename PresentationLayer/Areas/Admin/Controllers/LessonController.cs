using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LessonController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonService _lessonService;
        private readonly IGradeService _gradeService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<Lesson> _validator;
        private readonly IToastNotification _toast;

        public LessonController(ILessonService lessonService, IMapper mapper, IValidator<Lesson> validator, IToastNotification toast, IGradeService gradeService, IUserService userService, IAboutService aboutService)
        {
            _lessonService = lessonService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _gradeService = gradeService;
            _userService = userService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessons = await _lessonService.GetListAsync();
            var mapLessons=_mapper.Map<List<LessonListDto>>(lessons);
            return View(mapLessons);
        }
        public async Task<IActionResult> DeletedLessons()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessons = await _lessonService.GetDeletedListAsync();
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);
            return View(mapLessons);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var grades =await _gradeService.GetListAsync();
            var mapGrades = _mapper.Map<List<GradeDto>>(grades);

            var teachers = await _userService.TGetAllTeachersWithRoleAsync(); // Ogretmen kullanicilari listeleniyor.
            
            return View(new LessonAddDto { Grades= mapGrades, Users=teachers });
        }
        [HttpPost]
        public async Task<IActionResult> Add(LessonAddDto lessonAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapLesson = _mapper.Map<Lesson>(lessonAddDto);
            var result = await _validator.ValidateAsync(mapLesson);

            if (result.IsValid)
            {
                await _lessonService.TAddAsync(mapLesson);
                _toast.AddSuccessToastMessage(lessonAddDto.LessonName + " adlı ders başarıyla eklendi.", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Lesson", new { Area = "Admin" });
            }
            else
            {
                _toast.AddErrorToastMessage(lessonAddDto.LessonName + " adlı ders eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            var grades = await _gradeService.GetListAsync();
            var mapGrades = _mapper.Map<List<GradeDto>>(grades);

            var teachers = await _userService.TGetAllTeachersWithRoleAsync(); // Ogretmen kullanicilari listeleniyor.

            return View(new LessonAddDto { Grades = mapGrades,Users=teachers });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonId); // Id'ye gore dersi getir

            var grades = await _gradeService.GetListAsync(); // Tum siniflari getir
            var mapGrades=_mapper.Map<List<GradeDto>>(grades);

            var mapLesson = _mapper.Map<LessonUpdateDto>(lesson);
            mapLesson.Grades = mapGrades;

            var teachers = await _userService.TGetAllTeachersWithRoleAsync(); // Ogretmen kullanicilari listeleniyor.
            mapLesson.Users = teachers;

            return View(mapLesson);
        }
        [HttpPost]
        public async Task<IActionResult> Update(LessonUpdateDto lessonUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapLesson = _mapper.Map<Lesson>(lessonUpdateDto);
            var result = await _validator.ValidateAsync(mapLesson);

            if (result.IsValid)
            {
                await _lessonService.TUpdateAsync(mapLesson);
                _toast.AddSuccessToastMessage(lessonUpdateDto.LessonName + " adlı ders başarıyla güncellendi.", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Lesson", new { Area = "Admin" });
            }
            else if(lessonUpdateDto.GradeId.ToString() is null)
            {
                _toast.AddErrorToastMessage(lessonUpdateDto.LessonName + " adlı ders güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            else
            {
                _toast.AddErrorToastMessage(lessonUpdateDto.LessonName + " adlı ders güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            var grades = await _gradeService.GetListAsync();
            var mapGrades = _mapper.Map<List<GradeDto>>(grades);

            var teachers = await _userService.TGetAllTeachersWithRoleAsync(); // Ogretmen kullanicilari listeleniyor.

            return View(new LessonUpdateDto { Grades = mapGrades,Users=teachers });
        }
        public async Task<IActionResult> SafeDelete(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonName = await _lessonService.TSafeDeleteLessonAsync(lessonId);
            _toast.AddSuccessToastMessage(lessonName + " adlı ders başarıyla silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Lesson", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonName = await _lessonService.TUndoDeleteLessonAsync(lessonId);
            _toast.AddSuccessToastMessage(lessonName + " adlı ders başarıyla geri alındı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessons", "Lesson", new { Area = "Admin" });
        }
        [HttpPost]
		public async Task<IActionResult> HardDelete(Guid lessonId) // Tablodan tamamen silme islemi icin
		{
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonId);
			await _lessonService.TDeleteAsync(lesson);
			_toast.AddSuccessToastMessage("Ders tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
			return RedirectToAction("DeletedLessons", "Lesson", new { Area = "Admin" });
		}
	}
}
