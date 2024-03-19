using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Lessons;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IValidator<Lesson> _validator;
        private readonly IToastNotification _toastr;

        public LessonController(ILessonService lessonService, IMapper mapper, IValidator<Lesson> validator, IToastNotification toastr)
        {
            _lessonService = lessonService;
            _mapper = mapper;
            _validator = validator;
            _toastr = toastr;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.GetListAsync();
            var mapLessons = _mapper.Map<List<LessonListDto>>(lessons);
            return View(mapLessons);
        }
    }
}
