using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IValidator<Announcement> _validator;
        private readonly IToastNotification _toast;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper, IRoleService roleService, IValidator<Announcement> validator, IToastNotification toast)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _roleService = roleService;
            _validator = validator;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var announcements = await _announcementService.TTeacherAnnouncementListAsync();
            var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcements);
            return View(mapAnnouncements);
        }
        public async Task<IActionResult> Detail(Guid announcementId)
        {
            var announcement = await _announcementService.TGetByGuidAsync(announcementId);
            var mapAnnouncement = _mapper.Map<AnnouncementListDto>(announcement);
            return View(mapAnnouncement);
        }

        public async Task<IActionResult> StudentAnnouncements() // Ogrencilere yapilan duyurular listesi
        {
            var announcements = await _announcementService.TAnnouncementToStudentsListAsync();
            var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcements);
            return View(mapAnnouncements);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var role = await _roleService.TGetStudentRoleAsync(); // Yalnızca ogrenci rolundekilere duyuru yapmak için
            var mapRole = _mapper.Map<RoleListDto>(role);
            ViewBag.Rol = mapRole.Name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnnouncementAddDto announcementAddDto)
        {
            var mapAnnouncement = _mapper.Map<Announcement>(announcementAddDto);
            var result = await _validator.ValidateAsync(mapAnnouncement);

            var role = await _roleService.TGetStudentRoleAsync();
            var mapRole = _mapper.Map<RoleListDto>(role);

            var studentRoleId = await _roleService.TGetByIdRoleAsync(mapRole.Name);

            if (result.IsValid)
            {
                mapAnnouncement.RoleId = studentRoleId; // Ogrenci rolunun id'sini atadik
                await _announcementService.TAddAsync(mapAnnouncement);
                _toast.AddSuccessToastMessage(Messages.Announcement.Add(announcementAddDto.Title), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("StudentAnnouncements", "Announcement", new { Area = "Teacher" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Duyuru eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
            } 

            return View();
        }
    }
}
