using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = RoleConsts.Student)]
    public class LessonVideoController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonVideoService _lessonVideoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonVideoController(IAboutService aboutService, ILessonVideoService lessonVideoService, ILessonService lessonService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _aboutService = aboutService;
            _lessonVideoService = lessonVideoService;
            _lessonService = lessonService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ListVideoByLesson(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            var lessonVideos = await _lessonVideoService.TGetAllVideosByLessonId(lessonId); // Bulunan ders nesnesi ile o derse yuklenmis videolar.
            var mapLessonVideos = _mapper.Map<List<LessonVideoListDto>>(lessonVideos);

            var lesson = await _lessonService.TGetByGuidAsync(lessonId); // Gelen ders id'sine gore ders nesnesi bulunuyor
            ViewBag.LessonName = lesson.LessonName;
            return View(mapLessonVideos);
        }

        public async Task<IActionResult> Detail(Guid lessonVideoId)
        {
            var lessonVideo = await _lessonVideoService.TGetByGuidAsync(lessonVideoId); // Gelen id ile o video bulunuyor

            // Asagidaki satir ile Student panelinde giris yapan ogrenci videonun detayina basarak o videoyu izlemeye basladigi an Visitor ve
            //LessonVideoVisitor tablolarina ilgili bilgiler kaydedilecek ve ilgili videonun goruntulenme sayisi bir arttirilacak.
            await _lessonVideoService.TIncreaseTheCountOfViewsOfTheLessonVideo(lessonVideo);

            var mapLessonVideo = _mapper.Map<LessonVideoListDto>(lessonVideo);
            ViewBag.LessonVideoTitle = mapLessonVideo.Title;
            return View(mapLessonVideo);
        }
    }
}
