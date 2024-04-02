using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LessonDocumentController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILessonDocumentService _lessonDocumentService;
        private readonly ILessonService _lessonService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonDocumentAddDto> _validator;
        private readonly IToastNotification _toast;
        private readonly IUnitOfWork _unitOfWork;

        public LessonDocumentController(IAboutService aboutService, ILessonDocumentService lessonDocumentService, ILessonService lessonService, IUserService userService, IMapper mapper, IValidator<LessonDocumentAddDto> validator, IToastNotification toast, IUnitOfWork unitOfWork)
        {
            _aboutService = aboutService;
            _lessonDocumentService = lessonDocumentService;
            _lessonService = lessonService;
            _userService = userService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocuments = await _lessonDocumentService.GetListAsync();
            var mapLessonDocument = _mapper.Map<List<LessonDocumentListDto>>(lessonDocuments);
            foreach (var lessonDocument in mapLessonDocument)
            {
                var teacher = await _userService.TGetAppUserByIdAsync(lessonDocument.CreatedBy); // Dokumani yukleyen ogretmeni bul
                lessonDocument.LessonDocumentTeacherInfo = teacher.Name + " " + teacher.Surname; // Dersi veren ogretmenin ad soyad bilgisini view'da gosterebilmek icin
            }
            return View(mapLessonDocument);
        }

        public async Task<IActionResult> DeletedLessonDocuments()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocuments = await _lessonDocumentService.GetDeletedListAsync(); // Silinmis tum dokumanlari listele
            var mapLessonDocument = _mapper.Map<List<LessonDocumentListDto>>(lessonDocuments);
            foreach (var lessonDocument in mapLessonDocument)
            {
                var teacher = await _userService.TGetAppUserByIdAsync(lessonDocument.CreatedBy); // Dokumani yukleyen ogretmeni bul
                lessonDocument.LessonDocumentTeacherInfo = teacher.Name + " " + teacher.Surname; // Dersi veren ogretmenin ad soyad bilgisini view'da gosterebilmek icin              
            }
            return View(mapLessonDocument);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid lessonDocumentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocument = await _lessonDocumentService.TGetByGuidAsync(lessonDocumentId);
            var mapLessonDocument = _mapper.Map<LessonDocumentUpdateDto>(lessonDocument);

            var lesson = await _lessonService.TGetByGuidAsync(lessonDocument.LessonId); // Gelen dokumandaki LessonId'ye gore o dersi bul.

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

                return RedirectToAction("Index", "LessonDocument", new { Area = "Admin" });
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
            return RedirectToAction("Index", "LessonDocument", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid lessonDocumentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocumentTitle = await _lessonDocumentService.TUndoDeleteLessonDocumentAsync(lessonDocumentId);

            _toast.AddSuccessToastMessage(Messages.LessonDocument.UndoDelete(lessonDocumentTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonDocuments", "LessonDocument", new { Area = "Admin" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid lessonDocumentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var lessonDocument = await _lessonDocumentService.TGetByGuidAsync(lessonDocumentId);
            await _lessonDocumentService.TDeleteAsync(lessonDocument);

            _toast.AddSuccessToastMessage("Materyal tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedLessonDocuments", "LessonDocument", new { Area = "Admin" });
        }
    }
}
