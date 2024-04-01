using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonScores;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LessonScoreController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonScoreService _lessonScoreService;
        private readonly ILessonService _lessonService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonScore> _validator;
        private readonly IToastNotification _toast;
        private readonly IUnitOfWork _unitOfWork;

        public LessonScoreController(ILessonScoreService lessonScoreService, IUserService userService, IMapper mapper, IValidator<LessonScore> validator, IToastNotification toast, IUnitOfWork unitOfWork, ILessonService lessonService, IAboutService aboutService)
        {
            _lessonScoreService = lessonScoreService;
            _userService = userService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _unitOfWork = unitOfWork;
            _lessonService = lessonService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScores = await _lessonScoreService.GetListAsync();
            var mapLessonScores = _mapper.Map<List<LessonScoreListDto>>(lessonScores);
            foreach(var lessonScore in mapLessonScores)
            {
                var teacher=await _userService.TGetAppUserByIdAsync(lessonScore.CreatedBy);
                lessonScore.LessonTeacher = teacher.Name + " " + teacher.Surname; // Dersi veren ogretmenin ad soyad bilgisini view'da gosterebilmek icin
            }
            return View(mapLessonScores);
        }

        public async Task<IActionResult> DeletedLessonScores()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScores = await _lessonScoreService.GetDeletedListAsync();
            var mapLessonScores = _mapper.Map<List<LessonScoreListDto>>(lessonScores);
            foreach (var lessonScore in mapLessonScores)
            {
                var teacher = await _userService.TGetAppUserByIdAsync(lessonScore.CreatedBy);
                lessonScore.LessonTeacher = teacher.Name + " " + teacher.Surname; // Dersi veren ogretmenin ad soyad bilgisini view'da gosterebilmek icin
            }
            return View(mapLessonScores);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScore = await _lessonScoreService.TGetByGuidAsync(lessonScoreId);
            var mapLessonScore = _mapper.Map<LessonScoreUpdateDto>(lessonScore);

            var lesson = await _lessonService.TGetByGuidAsync(mapLessonScore.LessonId);

            ViewBag.LessonName = lesson.LessonName;

            ViewBag.LessonId = mapLessonScore.LessonId;
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

                return RedirectToAction("Index", "LessonScore", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Not bilgileri güncellenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }
            var lesson = await _lessonService.TGetByGuidAsync(mapLessonScore.LessonId);

            ViewBag.LessonName = lesson.LessonName;

            ViewBag.LessonId = mapLessonScore.LessonId;
            ViewBag.UserId = mapLessonScore.UserId;
            ViewBag.CreatedBy = mapLessonScore.CreatedBy;
            return View();
        }
        public async Task<IActionResult> SafeDelete(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            await _lessonScoreService.TSafeDeleteLessonScoreAsync(lessonScoreId);
            _toast.AddSuccessToastMessage("Not bilgileri başarıyla kaldırıldı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "LessonScore", new { Area = "Admin" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonScore = await _lessonScoreService.TGetByGuidAsync(lessonScoreId);
            await _lessonScoreService.TDeleteAsync(lessonScore);
            _toast.AddSuccessToastMessage("Not bilgileri tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonScores", "LessonScore", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid lessonScoreId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            await _lessonScoreService.TUndoDeleteLessonScoreAsync(lessonScoreId);
            _toast.AddSuccessToastMessage("Not bilgileri başarıyla geri alındı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonScores", "LessonScore", new { Area = "Admin" });
        }
    }
}
