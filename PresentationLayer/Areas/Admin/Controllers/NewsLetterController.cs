using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using EntityLayer.DTOs.NewsLetters;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsletterService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;
        private readonly IValidator<NewsLetterSendEmailDto> _validator;

        public NewsLetterController(INewsLetterService newsletterService, IMapper mapper, IToastNotification toast, IValidator<NewsLetterSendEmailDto> validator)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
            _toast = toast;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var newsLetters = await _newsletterService.GetListAsync();
            var mapNewsLetters = _mapper.Map<List<NewsLetterListDto>>(newsLetters);
            return View(mapNewsLetters);
        }
        public async Task<IActionResult> DeletedNewsLetters()
        {
            var newsLetters = await _newsletterService.GetDeletedListAsync();
            var mapNewsLetters = _mapper.Map<List<NewsLetterListDto>>(newsLetters);
            return View(mapNewsLetters);
        }
        public async Task<IActionResult> Delete(int newsLetterId)
        {
            var newsLetterEMail = await _newsletterService.TSafeDeleteNewsLetterAsync(newsLetterId);
            _toast.AddSuccessToastMessage(newsLetterEMail + " adlı mail başarıyla silindi", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "NewsLetter", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(int newsLetterId)
        {
            var newsLetterEMail = await _newsletterService.TUndoDeleteNewsLetterAsync(newsLetterId);
            _toast.AddSuccessToastMessage(newsLetterEMail + " adlı mail başarıyla geri alındı", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedNewsLetters", "NewsLetter", new { Area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> SendingBulkEmails()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendingBulkEmails(NewsLetterSendEmailDto newsLetterSendEmailDto)
        {
            var eMails = await _newsletterService.GetListAsync(); // Tum aboneler listeleniyor
            var mapEmails = _mapper.Map<List<NewsLetterDto>>(eMails); // NewsLetterDto'ya map'leme islemi
            try
            {
                var validation = await _validator.ValidateAsync(newsLetterSendEmailDto);
                if (validation.IsValid)
                {
                    _newsletterService.TSendingBulkEmails(newsLetterSendEmailDto,mapEmails);
                    _toast.AddSuccessToastMessage("Mailler başarıyla gönderildi.", new ToastrOptions { Title = "İşlem Başarılı!" });
                    return RedirectToAction("Index", "NewsLetter", new { Area = "Admin" });
                }
                else
                {
                    validation.AddToModelState(this.ModelState);
                }
            }
            catch (Exception ex)
            {
                _toast.AddErrorToastMessage(ex.Message, new ToastrOptions { Title = "İşlem Başarısız!" });
            }
            return View();
        }
    }
}
