using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonScores;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LessonScoreController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonScoreService _lessonScoreService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonScore> _validator;
        private readonly IToastNotification _toast;
        private readonly IUnitOfWork _unitOfWork;

        public LessonScoreController(ILessonScoreService lessonScoreService, ILessonService lessonService, IMapper mapper, IValidator<LessonScore> validator, IToastNotification toast, IUnitOfWork unitOfWork, IAboutService aboutService)
        {
            _lessonScoreService = lessonScoreService;
            _lessonService = lessonService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _unitOfWork = unitOfWork;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScores = await _lessonScoreService.TGetListLoginTeacherLessonScore();
            var mapLessonScores = _mapper.Map<List<LessonScoreListDto>>(lessonScores);
            return View(mapLessonScores);
        }

        public async Task<IActionResult> DeletedLessonScores()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScores = await _lessonScoreService.TGetDeletedListLoginTeacherLessonScore();
            var mapLessonScores = _mapper.Map<List<LessonScoreListDto>>(lessonScores);
            return View(mapLessonScores);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid userId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var student = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, g => g.Grade, i => i.Image);

            ViewBag.StudentId = userId;
            ViewBag.StudentNo = student.StudentNo;
            ViewBag.GradeName = student.Grade.Name;

            var lessons = await _lessonService.TLessonsInTheStudentsGrade(userId);  // Ogrencinin bulundugu siniftaki dersler listelencek (sadece o ogretmenin verdigi dersler)

            return View(new LessonScoreAddDto { Lessons = lessons });
        }
        [HttpPost]
        public async Task<IActionResult> Add(LessonScoreAddDto lessonScoreAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var student = await _unitOfWork.GetRepository<AppUser>()
                .GetAsync(x => x.Id == lessonScoreAddDto.UserId);

            var mapLessonScore = _mapper.Map<LessonScore>(lessonScoreAddDto);
            var result = await _validator.ValidateAsync(mapLessonScore);
            if (result.IsValid)
            {
                await _lessonScoreService.TAddAsync(mapLessonScore);
                _toast.AddSuccessToastMessage("Not bilgileri başarıyla eklendi.", new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "Student", new { Area = "Teacher" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Not bilgileri eklenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }
            var lessons = await _lessonService.TLessonsInTheStudentsGrade(student.Id);

            ViewBag.StudentId = student.Id;
            ViewBag.StudentNo = student.StudentNo;
            ViewBag.GradeName = student.Grade.Name;

            return View(new LessonScoreAddDto { Lessons = lessons });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScore = await _lessonScoreService.TGetByGuidAsync(lessonScoreId);
            var mapLessonScore=_mapper.Map<LessonScoreUpdateDto>(lessonScore);

            var lessons = await _lessonService.TLessonsInTheStudentsGrade(mapLessonScore.UserId);  // Ogrencinin bulundugu siniftaki dersler listelencek (sadece o ogretmenin verdigi dersler)
            mapLessonScore.Lessons = lessons;

            ViewBag.UserId = mapLessonScore.UserId;
            ViewBag.CreatedBy = mapLessonScore.CreatedBy; // Notu ekleyen ogretmenin id bilgisi yer aliyor.

            return View(mapLessonScore);
        }
        [HttpPost]
        public async Task<IActionResult> Update(LessonScoreUpdateDto lessonScoreUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapLessonScore = _mapper.Map<LessonScore>(lessonScoreUpdateDto);
            var result = await _validator.ValidateAsync(mapLessonScore);
            if (result.IsValid)
            {
                await _lessonScoreService.TUpdateAsync(mapLessonScore);
                _toast.AddSuccessToastMessage("Not bilgileri başarıyla güncellendi.", new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "LessonScore", new { Area = "Teacher" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Not bilgileri güncellenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }
            var lessons = await _lessonService.TLessonsInTheStudentsGrade(lessonScoreUpdateDto.UserId);

            ViewBag.UserId = mapLessonScore.UserId;
            ViewBag.CreatedBy = mapLessonScore.CreatedBy;

            return View(new LessonScoreUpdateDto { Lessons = lessons });
        }

        public async Task<IActionResult> SafeDelete(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            await _lessonScoreService.TSafeDeleteLessonScoreAsync(lessonScoreId);
            _toast.AddSuccessToastMessage("Not bilgileri başarıyla kaldırıldı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "LessonScore", new { Area = "Teacher" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScore = await _lessonScoreService.TGetByGuidAsync(lessonScoreId);
            await _lessonScoreService.TDeleteAsync(lessonScore);
            _toast.AddSuccessToastMessage("Not bilgileri tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonScores", "LessonScore", new { Area = "Teacher" });
        }

        public async Task<IActionResult> UndoDelete(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            await _lessonScoreService.TUndoDeleteLessonScoreAsync(lessonScoreId);
            _toast.AddSuccessToastMessage("Not bilgileri başarıyla geri alındı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonScores", "LessonScore", new { Area = "Teacher" });
        }
    }
}
