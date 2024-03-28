using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;
using System.Security.Claims;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LessonDocumentController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonDocumentService _lessonDocumentService;
        private readonly ILessonService _lessonService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonDocumentAddDto> _validator;

        public LessonDocumentController(ILessonDocumentService lessonDocumentService, IToastNotification toast, ILessonService lessonService, IMapper mapper, IValidator<LessonDocumentAddDto> validator, IAboutService aboutService)
        {
            _lessonDocumentService = lessonDocumentService;
            _toast = toast;
            _lessonService = lessonService;
            _mapper = mapper;
            _validator = validator;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> ListDocumentByLesson(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonId);
            var lessonDocuments = await _lessonDocumentService.TGetAllDocumentsByLesson(lesson);
            var mapLessonDocuments = _mapper.Map<List<LessonDocumentListDto>>(lessonDocuments);
            ViewBag.LessonName = lesson.LessonName;

            return View(mapLessonDocuments);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonId);
            ViewBag.LessonId = lessonId; 
            ViewBag.LessonName = lesson.LessonName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(LessonDocumentAddDto lessonDocumentAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonDocumentAddDto.LessonId);

            ViewBag.LessonId = lessonDocumentAddDto.LessonId;
            ViewBag.LessonName = lesson.LessonName;

            var result = await _validator.ValidateAsync(lessonDocumentAddDto);

            if (result.IsValid)
            {
                await _lessonDocumentService.TAddLessonDocumentAsync(lessonDocumentAddDto);
                _toast.AddSuccessToastMessage(Messages.LessonDocument.Add(lessonDocumentAddDto.Title), new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "Lesson", new { Area = "Teacher" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Ders materyali yüklenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }
            return View();
        }
    }
}
