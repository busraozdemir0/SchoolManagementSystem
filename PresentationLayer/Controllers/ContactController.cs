using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Contacts;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NToastNotify;

namespace PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IValidator<Contact> _validator;
        private readonly IToastNotification _toast;  // Mesaj eklendiginde bicimli bir sekilde bildirim mesaji verebilmek icin NToastNotify adli kutuphaneyi kullaniyoruz.
        public ContactController(IContactService contactService, IMapper mapper, IValidator<Contact> validator, IToastNotification toast)
        {
            _contactService = contactService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactAddDto contactAddDto)
        {
            var map=_mapper.Map<Contact>(contactAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _contactService.TAddAsync(map);
                _toast.AddSuccessToastMessage("Mesajınız başarıyla gönderildi.", new ToastrOptions { Title = "İşlem Başarılı!" });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                 result.AddToModelState(this.ModelState);

                _toast.AddErrorToastMessage("Mesajınız gönderilirken bir hata oluştu.", new ToastrOptions { Title = "İşlem Başarısız!" });
            }
            return RedirectToAction("Index", "Contact");
        }
        
    }
}
