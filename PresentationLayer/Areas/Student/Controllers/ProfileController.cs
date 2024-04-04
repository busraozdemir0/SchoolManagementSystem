using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Student.Controllers
{
	[Area("Student")]
	public class ProfileController : Controller
	{
        private readonly IAboutService _aboutService;
        private readonly IUserService _userService;
        private readonly IGradeService _gradeService;
		private readonly IMapper _mapper;
		private readonly IValidator<AppUser> _validator;
		private readonly IToastNotification _toast;

        public ProfileController(IUserService userService, IMapper mapper, IValidator<AppUser> validator, IToastNotification toast, IAboutService aboutService, IGradeService gradeService)
        {
            _userService = userService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _aboutService = aboutService;
            _gradeService = gradeService;
        }

        [HttpGet]
		public async Task<IActionResult> Update()
		{
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var profile = await _userService.TGetUserProfileAsync(); // Giren kisinin bilgileri
            var grade = await _gradeService.TGetGradeByIdAsync(profile.GradeId); // Giren ogrencinin sınıfını bul
            ViewBag.GradeName = grade.Name;

            ViewBag.Gender=profile.Gender;
			ViewBag.StudentNo=profile.StudentNo;
			ViewBag.GradeId = profile.GradeId;

			ViewBag.DefaultProfileImage = "user-avatar-profile.png"; // Eger hic profil resmi yuklenmemisse varsayilan resim gosterilecek.

			return View(profile);
		}
		[HttpPost]
		public async Task<IActionResult> Update(UserProfileDto userProfileDto)
		{
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapUser = _mapper.Map<AppUser>(userProfileDto);
			var validation = await _validator.ValidateAsync(mapUser);

			if (validation.IsValid)
			{
				var result = await _userService.TUserProfileUpdateAsync(userProfileDto);
				if (result)
				{
					_toast.AddSuccessToastMessage("Profil güncelleme işlemi başarıyla tamamlandı.", new ToastrOptions { Title = "İşlem Başarılı!" });
					return RedirectToAction("Update", "Profile", new { Area = "Student" });
				}
				else
				{
					var profile = await _userService.TGetUserProfileAsync();

					_toast.AddErrorToastMessage("Profil güncelleme işlemi sırasında bir sorun oluştu.", new ToastrOptions { Title = "İşlem Başarısız!" });
					return View(profile);
				}
			}
			else
			{
				var profile = await _userService.TGetUserProfileAsync();
				ViewBag.DefaultProfileImage = "user-avatar-profile.png";

				validation.AddToModelState(this.ModelState);
				return View(profile);
			}
		}
	}
}
