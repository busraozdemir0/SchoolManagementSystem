using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.NewsLetters;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterService;
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public NewsLetterController(INewsLetterService newsLetterService, IMapper mapper, IToastNotification toast, IAboutService aboutService)
        {
            _newsLetterService = newsLetterService;
            _mapper = mapper;
            _toast = toast;
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<PartialViewResult> NewsLetterMail()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            return PartialView();
        }
        [HttpPost]
        public async Task<PartialViewResult> NewsLetterMail(NewsLetterDto newsLetterDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var map = _mapper.Map<NewsLetter>(newsLetterDto);

            if (ModelState.IsValid)
            {
                await _newsLetterService.TAddAsync(map);
                _toast.AddSuccessToastMessage("Haber bültenine başarıyla abone oldunuz.", new ToastrOptions { Title = "İşlem Başarılı!" });
                Response.Redirect("/Home/Index", true); // Kaydedildikten sonra NewsLetterMail adli sayfaya gitmemesi icin
                return PartialView();
            }
            else
            {
                _toast.AddErrorToastMessage("Haber bültenine abone olunurken bir hatayla karşılaşıldı.", new ToastrOptions { Title = "İşlem Başarısız!" });
            }
            return PartialView();
        }
    }
}
