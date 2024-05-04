using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Abouts;
using EntityLayer.DTOs.SocialMedias;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class SocialMediaController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<SocialMedia> _validator;

        public SocialMediaController(IAboutService aboutService, ISocialMediaService socialMediaService, IToastNotification toast, IMapper mapper, IValidator<SocialMedia> validator)
        {
            _aboutService = aboutService;
            _socialMediaService = socialMediaService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var socialMedias=await _socialMediaService.GetListAsync();
            var mapSocialMedias=_mapper.Map<List<SocialMediaListDto>>(socialMedias);
            return View(mapSocialMedias);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int socialMediaId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var socialMedia = await _socialMediaService.TGetByIdAsync(socialMediaId);
            var mapSocialMedia = _mapper.Map<SocialMediaUpdateDto>(socialMedia);
            return View(mapSocialMedia);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            var mapSocialMedia = _mapper.Map<SocialMedia>(socialMediaUpdateDto);
            var result = await _validator.ValidateAsync(mapSocialMedia);

            if (result.IsValid)
            {
                await _socialMediaService.TUpdateAsync(mapSocialMedia);
                _toast.AddSuccessToastMessage(socialMediaUpdateDto.Title+ " adlı sosyal medya bilgisi başarıyla güncellendi.", new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "SocialMedia", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Sosyal medya bilgisi güncellenirken bir hata oluştu.", new ToastrOptions { Title = "Başarısız!" });
                return View();
            }
        }
    }
}
