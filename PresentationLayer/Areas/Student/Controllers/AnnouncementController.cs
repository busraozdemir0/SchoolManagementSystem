using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Announcements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.Controllers
{
	[Area("Student")]
    [Authorize(Roles = RoleConsts.Student)] // Rolu Student olan kullanicilar erisebilecek
    public class AnnouncementController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly IAnnouncementService _announcementService;
		private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper, IAboutService aboutService)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
		{
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var announcements = await _announcementService.TStudentAnnouncementListAsync(); // Duyurular icerisinde Ogrenci ve User rolu kullanilarak yapilan duyurular listelenecek.
			var announcementsOrderBy = announcements.OrderByDescending(x => x.CreatedDate); // En yeni duyuru en uste olmasi icin tarihe gore azalan bizimde siraladik.
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
    }
}
