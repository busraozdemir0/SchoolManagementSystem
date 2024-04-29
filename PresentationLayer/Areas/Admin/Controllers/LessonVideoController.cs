using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.Users;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class LessonVideoController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonVideoService _lessonVideoService;
        private readonly ILessonService _lessonService;
        private readonly IUserService _userService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonVideoAddDto> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public LessonVideoController(IAboutService aboutService, ILessonVideoService lessonVideoService, ILessonService lessonService, IToastNotification toast, IMapper mapper, IValidator<LessonVideoAddDto> validator, IUnitOfWork unitOfWork, IUserService userService)
        {
            _aboutService = aboutService;
            _lessonVideoService = lessonVideoService;
            _lessonService = lessonService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideos = await _lessonVideoService.GetListAsync();
            var mapLessonVideo = _mapper.Map<List<LessonVideoListDto>>(lessonVideos);
            foreach (var lessonVideo in mapLessonVideo)
            {
                var teacher = await _userService.TGetAppUserByIdAsync(lessonVideo.CreatedBy); // Videoyu yukleyen ogretmeni bul
                lessonVideo.LessonVideoTeacherInfo = teacher.Name + " " + teacher.Surname; // Dersi veren ogretmenin ad soyad bilgisini view'da gosterebilmek icin
            }
            return View(mapLessonVideo);
        }

        public async Task<IActionResult> DeletedLessonVideos()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideos = await _lessonVideoService.GetDeletedListAsync(); // Silinmis tum videolari listele
            var mapLessonVideo = _mapper.Map<List<LessonVideoListDto>>(lessonVideos);
            foreach (var lessonVideo in mapLessonVideo)
            {
                var teacher = await _userService.TGetAppUserByIdAsync(lessonVideo.CreatedBy); // Videoyu yukleyen ogretmeni bul
                lessonVideo.LessonVideoTeacherInfo = teacher.Name + " " + teacher.Surname; // Dersi veren ogretmenin ad soyad bilgisini view'da gosterebilmek icin              
            }
            return View(mapLessonVideo);
        }

        public async Task<IActionResult> StudentsWatchingTheLessonVideo(Guid lessonVideoId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideo = await _lessonVideoService.TGetByGuidAsync(lessonVideoId); // Gonderilen lessonVideoId ile o nesne bulunuyor.
            var lesson = await _lessonService.TGetByGuidAsync(lessonVideo.LessonId);
            ViewBag.LessonId = lessonVideo.LessonId;
            ViewBag.LessonName = lesson.LessonName;
            ViewBag.LessonVideoTitle = lessonVideo.Title;


            //İlgili dersteki videolari ve ilgili videoyu izleyen ogrenciler listeleniyor.
            var studentsWatchingTheLessonVideo = await _lessonVideoService.TStudentsWatchingTheLessonVideo(lessonVideoId);
            var mapStudentsWatchingTheLessonVideo = _mapper.Map<HashSet<UserListDto>>(studentsWatchingTheLessonVideo);

            return View(mapStudentsWatchingTheLessonVideo);
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

                return RedirectToAction("Index", "LessonVideo", new { Area = "Admin" }); 
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Ders videosu güncellenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
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

            _toast.AddSuccessToastMessage(Messages.LessonVideo.Delete(lessonVideoTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "LessonVideo", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid lessonVideoId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideoTitle = await _lessonVideoService.TUndoDeleteLessonVideoAsync(lessonVideoId);

            _toast.AddSuccessToastMessage(Messages.LessonVideo.UndoDelete(lessonVideoTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonVideos", "LessonVideo", new { Area = "Admin" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid lessonVideoId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonVideo = await _lessonVideoService.TGetByGuidAsync(lessonVideoId);
            await _lessonVideoService.TDeleteAsync(lessonVideo);

            _toast.AddSuccessToastMessage("Ders videosu tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonVideos", "LessonVideo", new { Area = "Admin" });
        }
    }
}
