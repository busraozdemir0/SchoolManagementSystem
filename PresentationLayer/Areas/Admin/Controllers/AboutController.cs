using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Abouts;
using EntityLayer.DTOs.Addresses;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)] // Rolu Admin olan kullanicilar erisebilecek
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<About> _validator;

        public AboutController(IAboutService aboutService, IToastNotification toast, IMapper mapper, IValidator<About> validator)
        {
            _aboutService = aboutService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var about = await _aboutService.GetListAsync();
            var mapAbout = _mapper.Map<AboutUpdateDto>(about.First());
            return View(mapAbout);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AboutUpdateDto aboutUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapAbout = _mapper.Map<About>(aboutUpdateDto);
            var result = await _validator.ValidateAsync(mapAbout);

            if (result.IsValid)
            {
                await _aboutService.TUpdateAboutAndImage(aboutUpdateDto);
                _toast.AddSuccessToastMessage("Hakkımızda bilgisi başarıyla güncellendi.", new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Update", "About", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Hakkımızda bilgisi güncellenirken bir hata oluştu.", new ToastrOptions { Title = "Başarısız!" });
            }

            var about = await _aboutService.GetListAsync();
            var mapAboutUpdateDto = _mapper.Map<AboutUpdateDto>(about.First());
            return View(new AboutUpdateDto { ImageId=mapAboutUpdateDto.ImageId, Image=mapAboutUpdateDto.Image});
        }
    }
}
