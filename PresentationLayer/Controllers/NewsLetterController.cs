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
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public NewsLetterController(INewsLetterService newsLetterService, IMapper mapper, IToastNotification toast)
        {
            _newsLetterService = newsLetterService;
            _mapper = mapper;
            _toast = toast;
        }

        [HttpGet]
        public async Task<PartialViewResult> NewsLetterMail()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<PartialViewResult> NewsLetterMail(NewsLetterDto newsLetterDto)
        {
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
