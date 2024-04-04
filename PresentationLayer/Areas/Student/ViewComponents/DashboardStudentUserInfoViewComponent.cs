using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Student.ViewComponents
{
	public class DashboardStudentUserInfoViewComponent:ViewComponent
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserService _userService;

		public DashboardStudentUserInfoViewComponent(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IUserService userService)
		{
			_httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _unitOfWork = unitOfWork;
			_userService = userService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var userId = _user.GetLoggedInUserId(); // Giren kisinin id'si
			var userName = _user.GetLoggedInUserName(); // Giren kisinin kullanici adi
			var user = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, i => i.Image);
			var userRole = await _userService.TGetUserRoleAsync(user);

			ViewBag.UserName = userName;

			ViewBag.NameSurname = user.Name+" "+user.Surname;

			if (user.UserAbout is not null)
				ViewBag.UserAbout = user.UserAbout;

			else
				ViewBag.UserAbout = "Okulumuzda en yetkin öğretmenlerimizden biridir.";


			ViewBag.GetLoggedInImageId = user.ImageId;

			if (user.ImageId is null)
				ViewBag.GetLoggedInImage = "user-avatar-profile.png"; // Profil resmi yuklenmemisse varsayilan resim gelsin.

			else
				ViewBag.GetLoggedInImage = user.Image.FileName;

			ViewBag.GetLoggedInRoleName = userRole;

			return View();
		}
	}
}
