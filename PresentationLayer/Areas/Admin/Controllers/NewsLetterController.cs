using AutoMapper;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using EntityLayer.DTOs.NewsLetters;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Reflection;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsletterService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public NewsLetterController(INewsLetterService newsletterService, IMapper mapper, IToastNotification toast)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
            _toast = toast;
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
            var newsLetterEMail= await _newsletterService.TSafeDeleteNewsLetterAsync(newsLetterId);
            _toast.AddSuccessToastMessage(newsLetterEMail+" adlı mail başarıyla silindi", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index","NewsLetter", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(int newsLetterId)
        {
            var newsLetterEMail = await _newsletterService.TUndoDeleteNewsLetterAsync(newsLetterId);
            _toast.AddSuccessToastMessage(newsLetterEMail + " adlı mail başarıyla geri alındı", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedNewsLetters", "NewsLetter", new { Area = "Admin" });
        }
    }
}
