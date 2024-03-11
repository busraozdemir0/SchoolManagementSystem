using DataAccessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class DashboardStatistics4ViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IUserService _userService;

        public DashboardStatistics4ViewComponent(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var user = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, i => i.Image);

            var getLoggedInUserName = _user.GetLoggedInUserName();
            ViewBag.GetLoggedInUserName = getLoggedInUserName;

            var getLoggedInEmail = _user.GetLoggedInEmail();
            ViewBag.GetLoggedInEmail = getLoggedInEmail;

            ViewBag.GetLoggedInNameSurname = user.Name + " " + user.Surname;

            ViewBag.GetLoggedInPhone = user.PhoneNumber;

            ViewBag.GetLoggedInAbout = user.UserAbout;

            ViewBag.GetLoggedInImageId = user.ImageId;

            if (user.ImageId is null)
                ViewBag.GetLoggedInImage = "user-avatar-profile.png"; // Profil resmi yuklenmemisse varsayilan resim gelsin.

            else
                ViewBag.GetLoggedInImage = user.Image.FileName;

            var totalGradeCount = await _unitOfWork.GetRepository<Grade>().CountAsync(x => !x.IsDeleted);
            ViewBag.TotalGradeCount = totalGradeCount;

            var totalReportCount = await _unitOfWork.GetRepository<Report>().CountAsync(x => !x.IsDeleted);
            ViewBag.TotalReportCount = totalReportCount;

            return View();
        }
    }
}
