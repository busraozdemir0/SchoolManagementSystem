using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LessonVideoController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonVideoService _lessonVideoService;
        private readonly ILessonService _lessonService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonVideoAddDto> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public LessonVideoController(IAboutService aboutService, ILessonVideoService lessonVideoService, ILessonService lessonService, IToastNotification toast, IMapper mapper, IValidator<LessonVideoAddDto> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _aboutService = aboutService;
            _lessonVideoService = lessonVideoService;
            _lessonService = lessonService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            return View();
        }
    }
}
