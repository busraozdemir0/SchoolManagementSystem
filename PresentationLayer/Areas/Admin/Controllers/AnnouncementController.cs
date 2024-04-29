using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class AnnouncementController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly IAnnouncementService _announcementService;
		private readonly IRoleService _roleService;
		private readonly IMapper _mapper;
		private readonly IValidator<EntityLayer.Entities.Announcement> _validator;
		private readonly IToastNotification _toast;
		private readonly IUserService _userService;


		public AnnouncementController(IAnnouncementService announcementService, IMapper mapper, IValidator<EntityLayer.Entities.Announcement> validator, IToastNotification toast, IRoleService roleService, IUserService userService, IAboutService aboutService)
		{
			_announcementService = announcementService;
			_mapper = mapper;
			_validator = validator;
			_toast = toast;
			_roleService = roleService;
			_userService = userService;
			_aboutService = aboutService;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var announcements = await _announcementService.GetListAsync();
			List<EntityLayer.Entities.Announcement> announcementList = new();
			foreach (var item in announcements)
			{
				var user = await _userService.TGetAppUserByIdAsync(item.UserId);
				var userRole = await _userService.TGetUserRoleAsync(user);
				if (userRole == RoleConsts.Admin) // Yalnızca Admin rolundeki kullanicinin yaptigi yorumlar listelenecek.
				{
					announcementList.Add(item);
				}
			}
			var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcementList);
			return View(mapAnnouncements);
		}
		public async Task<IActionResult> TeacherAnnouncements()
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var announcements = await _announcementService.GetListAsync();
			List<EntityLayer.Entities.Announcement> announcementList = new();
			foreach (var item in announcements)
			{
				var user = await _userService.TGetAppUserByIdAsync(item.UserId);
				var userRole = await _userService.TGetUserRoleAsync(user);
				if (userRole == RoleConsts.Teacher) // Yalnızca Teacher rolundeki kullanicinin yaptigi duyurular listelenecek
				{
					announcementList.Add(item);
				}
			}
			var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcementList);
			return View(mapAnnouncements);
		}
		public async Task<IActionResult> DeletedAnnouncements()
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var announcements = await _announcementService.GetDeletedListAsync();
			var mapAnnouncements = _mapper.Map<List<AnnouncementListDto>>(announcements);
			return View(mapAnnouncements);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var roles = await _roleService.TGetAllRolesAsync();
			var mapRoles = _mapper.Map<List<RoleListDto>>(roles);
			List<RoleListDto> roleList = new();
			foreach (var role in mapRoles)
			{
				if (!(role.Name == RoleConsts.Admin)) // Admin rolu haric diger rolleri listeye ekle
					roleList.Add(role);
			}
			return View(new AnnouncementAddDto { Roles = roleList });
		}

		[HttpPost]
		public async Task<IActionResult> Add(AnnouncementAddDto announcementAddDto)
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var mapAnnouncement = _mapper.Map<EntityLayer.Entities.Announcement>(announcementAddDto);
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
			List<RoleListDto> roleList = new();
			foreach (var role in mapRoles)
			{
				if (!(role.Name == RoleConsts.Admin))
					roleList.Add(role);
			}

			return View(new AnnouncementAddDto { Roles = roleList });
		}

		[HttpGet]
		public async Task<IActionResult> Update(Guid announcementId)
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var roles = await _roleService.TGetAllRolesAsync();
			var mapRoles = _mapper.Map<List<RoleListDto>>(roles); // Tum roller
			List<RoleListDto> roleList = new();
			foreach (var role in mapRoles)
			{
				if (!(role.Name == RoleConsts.Admin))
					roleList.Add(role);
			}

			var announcement = await _announcementService.TGetByGuidAsync(announcementId);
			var mapAnnouncement = _mapper.Map<AnnouncementUpdateDto>(announcement);

			mapAnnouncement.Roles = roleList;

			return View(mapAnnouncement);
		}

		[HttpPost]
		public async Task<IActionResult> Update(AnnouncementUpdateDto announcementUpdateDto)
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var mapAnnouncement = _mapper.Map<EntityLayer.Entities.Announcement>(announcementUpdateDto);
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
			List<RoleListDto> roleList = new();
			foreach (var role in mapRoles)
			{
				if (!(role.Name == RoleConsts.Admin))
					roleList.Add(role);
			}

			return View(new AnnouncementUpdateDto { Roles = roleList });

		}
		public async Task<IActionResult> SafeDelete(Guid announcementId)
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var announcementTitle = await _announcementService.TSafeDeleteAnnouncementAsync(announcementId);
			_toast.AddSuccessToastMessage(Messages.Announcement.Delete(announcementTitle), new ToastrOptions { Title = "Başarılı!" });
			return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
		}
		public async Task<IActionResult> UndoDelete(Guid announcementId)
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var announcementTitle = await _announcementService.TUndoDeleteAnnouncementAsync(announcementId);
			_toast.AddSuccessToastMessage(Messages.Announcement.UndoDelete(announcementTitle), new ToastrOptions { Title = "Başarılı!" });
			return RedirectToAction("DeletedAnnouncements", "Announcement", new { Area = "Admin" });
		}
		[HttpPost]
		public async Task<IActionResult> HardDelete(Guid announcementId) // Ogretmenlerin yaptigi veya cop kutusundaki duyuruları tamamen tablodan silebilmek icin
		{
			ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

			var announcement = await _announcementService.TGetByGuidAsync(announcementId);

			if (announcement is not null)
			{
				await _announcementService.TDeleteAsync(announcement);
				_toast.AddSuccessToastMessage("Duyuru tamamen silindi", new ToastrOptions { Title = "Başarılı!" });
				return RedirectToAction("DeletedAnnouncements", "Announcement", new { Area = "Admin" });
			}
			else
			{
				_toast.AddErrorToastMessage("Duyuru silinirken bir hata oluştu", new ToastrOptions { Title = "Başarısız!" });
			}
			return View();

		}
	}
}
