using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Teacher.ViewComponents
{
	public class DashboardLastSixReportViewComponent:ViewComponent
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public DashboardLastSixReportViewComponent(IMapper mapper, IUnitOfWork unitOfWork, ICommentService commentService, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _commentService = commentService;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var report = await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted, i => i.Image);

			var reportLastThree = report.OrderByDescending(x => x.CreatedDate).Take(6); // Haberleri tarihe gore azalan bicimde siralar ve ilk 6 haberi alir.

			var map = _mapper.Map<List<ReportDto>>(reportLastThree);

            var userId = _user.GetLoggedInUserId();
            var comments = await _commentService.GetListAsync();
            foreach (var comment in comments)
            {
                if (comment.UserId == userId)
                    ViewBag.ThereisaComment = true; // Eger giris yapan kullanici daha onceden yorum yapilmissa tekrar yorum yapma sayfasi gosterilmeyecek.
            }

            return View(map);
		}
	}
}
