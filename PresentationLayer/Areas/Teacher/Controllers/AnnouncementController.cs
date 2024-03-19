using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Announcements;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
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
	}
}
