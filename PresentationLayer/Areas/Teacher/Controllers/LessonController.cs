using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Lessons;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;
using static PresentationLayer.ResultMessages.Messages;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LessonController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IValidator<Lesson> _validator;
        private readonly IToastNotification _toastr;

        public LessonController(ILessonService lessonService, IMapper mapper, IValidator<Lesson> validator, IToastNotification toastr, IAboutService aboutService)
        {
            _lessonService = lessonService;
            _mapper = mapper;
            _validator = validator;
            _toastr = toastr;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessons = await _lessonService.TGetAllTeacherLessonsAsync();
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);
            return View(mapLessons);
        }
    }
}
