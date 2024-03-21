﻿using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Announcements;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Teacher.ViewComponents
{
	public class LastThreeAnnouncementViewComponent:ViewComponent
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserService _userService;

        public LastThreeAnnouncementViewComponent(IAnnouncementService announcementService, IMapper mapper, IUnitOfWork unitOfWork, IUserService userService)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var announcements = await _announcementService.TTeacherAnnouncementListAsync();

			var announcementsLastThree=announcements.OrderByDescending(x => x.CreatedDate).Take(3);

			var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcementsLastThree);

			ViewBag.AnnouncementsCount = announcements.Count;

			return View(mapAnnouncements);
		}
	}
}