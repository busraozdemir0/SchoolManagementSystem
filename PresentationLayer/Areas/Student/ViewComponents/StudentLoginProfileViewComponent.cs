using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Student.ViewComponents
{
    public class StudentLoginProfileViewComponent:ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
		private readonly IGradeService _gradeService;

		public StudentLoginProfileViewComponent(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IUserService userService, IGradeService gradeService)
		{
			_httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
			_unitOfWork = unitOfWork;
			_userService = userService;
			_gradeService = gradeService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _user.GetLoggedInUserId(); // Giren kisinin id'si
            var userName = _user.GetLoggedInUserName(); // Giren kisinin kullanici adi
            var user = await _unitOfWork.GetRepository<AppUser>().GetAsync(x=>x.Id==userId,i=>i.Image);

            ViewBag.UserName = userName;

            ViewBag.GetLoggedInImageId = user.ImageId;

            if (user.ImageId is null)
                ViewBag.GetLoggedInImage = "user-avatar-profile.png"; // Profil resmi yuklenmemisse varsayilan resim gelsin.

            else
                ViewBag.GetLoggedInImage = user.Image.FileName;

			var profile = await _userService.TGetUserProfileAsync(); // Giren kisinin bilgileri
			var grade = await _gradeService.TGetGradeByIdAsync(profile.GradeId); // Giren ogrencinin sınıfını bul
			ViewBag.StudentNo = profile.StudentNo;
			ViewBag.GradeName = grade.Name;
			
			return View();
        }
    }
}
