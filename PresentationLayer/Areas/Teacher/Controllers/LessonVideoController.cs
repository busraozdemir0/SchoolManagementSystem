using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.LessonVideos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;
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

        public async Task<IActionResult> ListVideoByLesson(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonId);
            var lessonVideos = await _lessonVideoService.TGetAllVideosByLesson(lesson);
            var mapLessonVideos = _mapper.Map<List<LessonVideoListDto>>(lessonVideos);
            ViewBag.LessonName = lesson.LessonName;

            return View(mapLessonVideos);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid lessonId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonId);
            ViewBag.LessonId = lessonId;
            ViewBag.LessonName = lesson.LessonName;
            return View(new LessonVideoAddDto { LessonId = lessonId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(LessonVideoAddDto lessonVideoAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lesson = await _lessonService.TGetByGuidAsync(lessonVideoAddDto.LessonId);

            ViewBag.LessonId = lessonVideoAddDto.LessonId;
            ViewBag.LessonName = lesson.LessonName;

            var result = await _validator.ValidateAsync(lessonVideoAddDto);

            if (result.IsValid)
            {
                await _lessonVideoService.TAddLessonVideoAsync(lessonVideoAddDto);
                _toast.AddSuccessToastMessage(Messages.LessonVideo.Add(lessonVideoAddDto.Title), new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "Lesson", new { Area = "Teacher" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Ders videosu yüklenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid lessonVideoId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideo = await _lessonVideoService.TGetByGuidAsync(lessonVideoId);
            var mapLessonVideo = _mapper.Map<LessonVideoUpdateDto>(lessonVideo);

            var lesson = await _lessonService.TGetByGuidAsync(lessonVideo.LessonId); // Gelen videodaki LessonId'ye gore o dersi bul.

            ViewBag.LessonId = lessonVideo.LessonId;
            ViewBag.LessonName = lesson.LessonName;
            ViewBag.CreatedBy = lessonVideo.CreatedBy;

            mapLessonVideo.LessonId = lesson.Id;
            mapLessonVideo.VideoId = lessonVideo.VideoId;
            return View(mapLessonVideo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LessonVideoUpdateDto lessonVideoUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapLessonVideoAddDto = _mapper.Map<LessonVideoAddDto>(lessonVideoUpdateDto);
            var result = await _validator.ValidateAsync(mapLessonVideoAddDto);

            if (result.IsValid)
            {
                await _lessonVideoService.TUpdateLessonVideoAsync(lessonVideoUpdateDto);
                _toast.AddSuccessToastMessage(Messages.LessonVideo.Update(lessonVideoUpdateDto.Title), new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("ListVideoByLesson", "LessonVideo",
                    new { Area = "Teacher", lessonId = lessonVideoUpdateDto.LessonId });  // lessonId ile ListVideoByLesson action'una dersin id'si ile gitmesini sagliyoruz.
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Ders materyali güncellenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }

            var lessonVideo = await _lessonVideoService.TGetByGuidAsync(lessonVideoUpdateDto.Id);
            var lesson = await _lessonService.TGetByGuidAsync(lessonVideo.LessonId); // Gelen dokumandaki LessonId'ye gore o dersi bul.
            var mapLessonVideoDto = _mapper.Map<LessonVideoUpdateDto>(lessonVideo);

            ViewBag.LessonId = lessonVideoUpdateDto.LessonId;
            ViewBag.LessonName = lesson.LessonName;
            ViewBag.CreatedBy = lessonVideo.CreatedBy;

            return View(new LessonVideoUpdateDto
            { VideoId = mapLessonVideoDto.VideoId, Video = mapLessonVideoDto.Video });
        }

        public async Task<IActionResult> SafeDelete(Guid lessonVideoId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideoTitle = await _lessonVideoService.TSafeDeleteLessonVideoAsync(lessonVideoId);
            var lessonVideo = await _lessonVideoService.TGetByGuidAsync(lessonVideoId);

            _toast.AddSuccessToastMessage(Messages.LessonVideo.Delete(lessonVideoTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("ListVideoByLesson", "LessonVideo",
                    new { Area = "Teacher", lessonId = lessonVideo.LessonId });
        }

        public async Task<IActionResult> DeletedLessonVideos()
        {
            var loginTeacherId = _user.GetLoggedInUserId();
            var lessonVideos = await _unitOfWork.GetRepository<EntityLayer.Entities.LessonVideo>().
                GetAllAsync(x => x.IsDeleted && x.CreatedBy == loginTeacherId.ToString(), l => l.Lesson, d => d.Video);

            var mapLessonVideos = _mapper.Map<List<LessonVideoListDto>>(lessonVideos);
            return View(mapLessonVideos);
        }

        public async Task<IActionResult> UndoDelete(Guid lessonVideoId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideoTitle = await _lessonVideoService.TUndoDeleteLessonVideoAsync(lessonVideoId);

            _toast.AddSuccessToastMessage(Messages.LessonVideo.UndoDelete(lessonVideoTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonVideos", "LessonVideo", new { Area = "Teacher" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid lessonVideoId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideo = await _lessonVideoService.TGetByGuidAsync(lessonVideoId);
            await _lessonVideoService.TDeleteAsync(lessonVideo);

            _toast.AddSuccessToastMessage("Ders videosu tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonVideos", "LessonVideo", new { Area = "Teacher" });
        }
    }
}
