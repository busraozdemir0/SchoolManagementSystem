﻿using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.Extensions;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;
using System.Security.Claims;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly IValidator<Announcement> _validator;
        private readonly IToastNotification _toast;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper, IRoleService roleService, IValidator<Announcement> validator, IToastNotification toast, IHttpContextAccessor httpContextAccessor, IUserService userService, IAboutService aboutService)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _roleService = roleService;
            _validator = validator;
            _toast = toast;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _userService = userService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index() // Admin kullanicisinin yaptigi duyurulari gosterecek view
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcements = await _announcementService.TTeacherAnnouncementListAsync();

            List<Announcement> announcementList = new();
            foreach (var item in announcements)
            {
                var user = await _userService.TGetAppUserByIdAsync(item.UserId);
                var userRole = await _userService.TGetUserRoleAsync(user);
                if (userRole == RoleConsts.Admin) // Yalnızca Admin rolundeki kullanicinin yaptigi yorumlar listelenecek.
                {
                    announcementList.Add(item);
                }
            }
            var announcementsOrderBy = announcementList.OrderByDescending(x => x.CreatedDate);
            var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcementsOrderBy);     
            return View(mapAnnouncements);
        }
        public async Task<IActionResult> Detail(Guid announcementId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcement = await _announcementService.TGetByGuidAsync(announcementId);
            var mapAnnouncement = _mapper.Map<AnnouncementListDto>(announcement);
            return View(mapAnnouncement);
        }
        public async Task<IActionResult> StudentAnnouncements() // Ogrencilere yapilan duyurular listesi
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcements = await _announcementService.TTeacherAnnouncementToStudentsListAsync();
            var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcements);
            return View(mapAnnouncements);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var role = await _roleService.TGetStudentRoleAsync(); // Yalnızca ogrenci rolundekilere duyuru yapmak için
            var mapRole = _mapper.Map<RoleListDto>(role);
            ViewBag.Rol = mapRole.Name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnnouncementAddDto announcementAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapAnnouncement = _mapper.Map<Announcement>(announcementAddDto);
            var result = await _validator.ValidateAsync(mapAnnouncement);

            var role = await _roleService.TGetStudentRoleAsync();
            var mapRole = _mapper.Map<RoleListDto>(role);

            var studentRoleId = await _roleService.TGetByIdRoleAsync(mapRole.Name);

            if (result.IsValid)
            {
                mapAnnouncement.RoleId = studentRoleId; // Yalnızca ogrencilere duyuru yapilacagi icin ogrenci rolunun id'sini atadik.
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

        [HttpGet]
        public async Task<IActionResult> Update(Guid announcementId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var role = await _roleService.TGetStudentRoleAsync(); // Yalnızca ogrenci rolundekilere duyuru yapmak için
            var mapRole = _mapper.Map<RoleListDto>(role);

            var announcement = await _announcementService.TGetByGuidAsync(announcementId);
            var mapAnnouncement = _mapper.Map<AnnouncementUpdateDto>(announcement);
            mapAnnouncement.Role = mapRole;

            return View(mapAnnouncement);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AnnouncementUpdateDto announcementUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            
            var mapAnnouncement = _mapper.Map<Announcement>(announcementUpdateDto);
            var result = await _validator.ValidateAsync(mapAnnouncement);

            var role = await _roleService.TGetStudentRoleAsync(); // Yalnızca ogrenci rolundekilere duyuru yapmak için
            var mapRole = _mapper.Map<RoleListDto>(role);

            var studentRoleId = await _roleService.TGetByIdRoleAsync(mapRole.Name);

            if (result.IsValid)
            {
                mapAnnouncement.RoleId = studentRoleId;
                await _announcementService.TUpdateAsync(mapAnnouncement);

                _toast.AddSuccessToastMessage(Messages.Announcement.Update(announcementUpdateDto.Title), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("StudentAnnouncements", "Announcement", new { Area = "Teacher" });
            }
            else if (announcementUpdateDto.RoleId.ToString() is null)
            {
                _toast.AddErrorToastMessage("Duyuru güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Duyuru güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
            }

            return View();
        }
        public async Task<IActionResult> DeletedAnnouncements()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcements = await _announcementService.TTeacherAnnouncementToStudentsDeletedListAsync();
            var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcements);
            return View(mapAnnouncements);
        }

        public async Task<IActionResult> Delete(Guid announcementId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcementTitle = await _announcementService.TSafeDeleteAnnouncementAsync(announcementId);
            _toast.AddSuccessToastMessage(Messages.Announcement.Delete(announcementTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("StudentAnnouncements", "Announcement", new { Area = "Teacher" });
        }
        public async Task<IActionResult> UndoDelete(Guid announcementId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcementTitle = await _announcementService.TUndoDeleteAnnouncementAsync(announcementId);
            _toast.AddSuccessToastMessage(Messages.Announcement.UndoDelete(announcementTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedAnnouncements", "Announcement", new { Area = "Teacher" });
        }

        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid announcementId) 
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcement = await _announcementService.TGetByGuidAsync(announcementId);

            if (announcement is not null)
            {
                await _announcementService.TDeleteAsync(announcement);
                _toast.AddSuccessToastMessage("Duyuru tamamen silindi", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("DeletedAnnouncements", "Announcement", new { Area = "Teacher" });
            }
            else
            {
                _toast.AddErrorToastMessage("Duyuru silinirken bir hata oluştu", new ToastrOptions { Title = "Başarısız!" });
            }
            return View();

        }
    }
}
