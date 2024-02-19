using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.NewsLetters;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterService;
        private readonly IMapper _mapper;
        private readonly IValidator<NewsLetter> _validator;
        private readonly IToastNotification _toast;

        public NewsLetterController(INewsLetterService newsLetterService, IMapper mapper, IValidator<NewsLetter> validator, IToastNotification toast)
        {
            _newsLetterService = newsLetterService;
            _mapper = mapper;
            _validator = validator;
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
            var result = _validator.Validate(map);
            if (result.IsValid)
            {
                await _newsLetterService.TAddAsync(map);
                _toast.AddSuccessToastMessage("Mail bültenine başarıyla abone olundu.", new ToastrOptions { Title = "Başarılı!" });
                Response.Redirect("/Home/Index", true); // Kaydedildikten sonra NewsLetterMail adli sayfaya gitmemesi icin
                return PartialView();
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Mail bültenine abone olunurken bir hatayla karşılaşıldı.", new ToastrOptions { Title = "Başarısız!" });
            }
            return PartialView();
        }
    }
}
