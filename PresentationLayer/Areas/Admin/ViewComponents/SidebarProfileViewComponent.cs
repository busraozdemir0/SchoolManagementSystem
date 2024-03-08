using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class SidebarProfileViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IUserService _userService;

        public SidebarProfileViewComponent(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IUserService userService)
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

            ViewBag.GetLoggedInImageId = user.ImageId;

            if (user.ImageId is null)
                ViewBag.GetLoggedInImage ="user-avatar-profile.png"; // Profil resmi yuklenmemisse varsayilan resim gelsin.

            else
                ViewBag.GetLoggedInImage = user.Image.FileName;

            return View();
        }
    }
}
