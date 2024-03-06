﻿using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.Consts;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IValidator<Announcement> _validator;
        private readonly IToastNotification _toast;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper, IValidator<Announcement> validator, IToastNotification toast, IRoleService roleService)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var announcements = await _announcementService.GetListAsync();
            var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcements);
            return View(mapAnnouncements);
        }
        public async Task<IActionResult> DeletedAnnouncements()
        {
            var announcements = await _announcementService.GetDeletedListAsync();
            var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcements);
            return View(mapAnnouncements);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleService.TGetAllRolesAsync();
            var mapRoles = _mapper.Map<List<RoleListDto>>(roles);
            return View(new AnnouncementAddDto { Roles = mapRoles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnnouncementAddDto announcementAddDto)
        {
            var mapAnnouncement = _mapper.Map<Announcement>(announcementAddDto);
            var result = await _validator.ValidateAsync(mapAnnouncement);

            if (result.IsValid)
            {
                await _announcementService.TAddAsync(mapAnnouncement);
                _toast.AddSuccessToastMessage(Messages.Announcement.Add(announcementAddDto.Title), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Duyuru eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
            }
            // Rolleri tekrar gondermedigimiz takdirde eger validasyon basarili olmazsa roller kisminda NullReference hatasi verir
            var roles = await _roleService.TGetAllRolesAsync(); // Tum roller
            var mapRoles = _mapper.Map<List<RoleListDto>>(roles);

            return View(new AnnouncementAddDto { Roles = mapRoles }); 
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid announcementId)
        {
            var roles = await _roleService.TGetAllRolesAsync();
            var mapRoles = _mapper.Map<List<RoleListDto>>(roles); // Tum roller

            var announcement = await _announcementService.TGetByGuidAsync(announcementId);
            var mapAnnouncement = _mapper.Map<AnnouncementUpdateDto>(announcement);
            mapAnnouncement.Roles = mapRoles;

            return View(mapAnnouncement);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AnnouncementUpdateDto announcementUpdateDto)
        {
            var mapAnnouncement = _mapper.Map<Announcement>(announcementUpdateDto);
            var result = await _validator.ValidateAsync(mapAnnouncement);

            if (result.IsValid)
            {
                await _announcementService.TUpdateAsync(mapAnnouncement);
                _toast.AddSuccessToastMessage(Messages.Announcement.Update(announcementUpdateDto.Title), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
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
            var roles = await _roleService.TGetAllRolesAsync(); // Tum roller
            var mapRoles = _mapper.Map<List<RoleListDto>>(roles);

            return View(new AnnouncementUpdateDto { Roles = mapRoles });

        }
        public async Task<IActionResult> Delete(Guid announcementId)
        {
            var announcementTitle = await _announcementService.TSafeDeleteAnnouncementAsync(announcementId);
            _toast.AddSuccessToastMessage(Messages.Announcement.Delete(announcementTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid announcementId)
        {
            var announcementTitle = await _announcementService.TUndoDeleteAnnouncementAsync(announcementId);
            _toast.AddSuccessToastMessage(Messages.Announcement.UndoDelete(announcementTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
        }
    }
}