using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;
using System.Security.Claims;
using static PresentationLayer.ResultMessages.Messages;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = RoleConsts.Teacher)]
    public class LessonDocumentController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonDocumentService _lessonDocumentService;
        private readonly ILessonService _lessonService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonDocumentAddDto> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public LessonDocumentController(ILessonDocumentService lessonDocumentService, IToastNotification toast, ILessonService lessonService, IMapper mapper, IValidator<LessonDocumentAddDto> validator, IAboutService aboutService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _lessonDocumentService = lessonDocumentService;
            _toast = toast;
            _lessonService = lessonService;
            _mapper = mapper;
            _validator = validator;
            _aboutService = aboutService;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _unitOfWork = unitOfWork;
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
            return View(new LessonDocumentAddDto { LessonId = lessonId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(LessonDocumentAddDto lessonDocumentAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

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

            var lesson = await _lessonService.TGetByGuidAsync(lessonDocumentAddDto.LessonId);

            ViewBag.LessonId = lessonDocumentAddDto.LessonId;
            ViewBag.LessonName = lesson.LessonName;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid lessonDocumentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocument = await _lessonDocumentService.TGetByGuidAsync(lessonDocumentId);
            var mapLessonDocument = _mapper.Map<LessonDocumentUpdateDto>(lessonDocument);
            
            var lesson = await _lessonService.TGetByGuidAsync(lessonDocument.LessonId); // Gelen dokumandaki Lessonıd'ye gore o dersi bul.

            ViewBag.LessonId = lessonDocument.LessonId;
            ViewBag.LessonName = lesson.LessonName;
            ViewBag.CreatedBy = lessonDocument.CreatedBy;

            mapLessonDocument.LessonId = lesson.Id;
            mapLessonDocument.DocumentId = lessonDocument.DocumentId;
            return View(mapLessonDocument);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LessonDocumentUpdateDto lessonDocumentUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapLessonDocumentAddDto = _mapper.Map<LessonDocumentAddDto>(lessonDocumentUpdateDto);
            var result = await _validator.ValidateAsync(mapLessonDocumentAddDto);

            if (result.IsValid)
            {
                await _lessonDocumentService.TUpdateLessonDocumentAsync(lessonDocumentUpdateDto);
                _toast.AddSuccessToastMessage(Messages.LessonDocument.Update(lessonDocumentUpdateDto.Title), new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("ListDocumentByLesson", "LessonDocument",
                    new { Area = "Teacher", lessonId = lessonDocumentUpdateDto.LessonId });  // lessonId ile ListDocumentByLesson action'una dersin id'si ile gitmesini sagliyoruz.
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Ders materyali güncellenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }

            var lessonDocument = await _lessonDocumentService.TGetByGuidAsync(lessonDocumentUpdateDto.Id);
            var lesson = await _lessonService.TGetByGuidAsync(lessonDocument.LessonId); // Gelen dokumandaki LessonId'ye gore o dersi bul.
            var mapLessonDocumentDto = _mapper.Map<LessonDocumentUpdateDto>(lessonDocument);

            ViewBag.LessonId = lessonDocumentUpdateDto.LessonId;
            ViewBag.LessonName = lesson.LessonName;
            ViewBag.CreatedBy = lessonDocument.CreatedBy;

            return View(new LessonDocumentUpdateDto
            { DocumentId = mapLessonDocumentDto.DocumentId, Document = mapLessonDocumentDto.Document });
        }

        public async Task<IActionResult> SafeDelete(Guid lessonDocumentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocumentTitle = await _lessonDocumentService.TSafeDeleteLessonDocumentAsync(lessonDocumentId);
            var lessonDocument = await _lessonDocumentService.TGetByGuidAsync(lessonDocumentId);

            _toast.AddSuccessToastMessage(Messages.LessonDocument.Delete(lessonDocumentTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("ListDocumentByLesson", "LessonDocument",
                    new { Area = "Teacher", lessonId = lessonDocument.LessonId });
        }

        public async Task<IActionResult> DeletedLessonDocuments()
        {
            var loginTeacherId = _user.GetLoggedInUserId();
            var lessonDocuments = await _unitOfWork.GetRepository<EntityLayer.Entities.LessonDocument>().
                GetAllAsync(x => x.IsDeleted && x.CreatedBy == loginTeacherId.ToString(), l => l.Lesson, d => d.Document);

            var mapLessonDocuments = _mapper.Map<List<LessonDocumentListDto>>(lessonDocuments);
            return View(mapLessonDocuments);
        }

        public async Task<IActionResult> UndoDelete(Guid lessonDocumentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocumentTitle = await _lessonDocumentService.TUndoDeleteLessonDocumentAsync(lessonDocumentId);

            _toast.AddSuccessToastMessage(Messages.LessonDocument.UndoDelete(lessonDocumentTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonDocuments", "LessonDocument", new { Area = "Teacher" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid lessonDocumentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocument = await _lessonDocumentService.TGetByGuidAsync(lessonDocumentId);
            await _lessonDocumentService.TDeleteAsync(lessonDocument);

            _toast.AddSuccessToastMessage("Materyal tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonDocuments", "LessonDocument", new { Area = "Teacher" });
        }
    }
}
