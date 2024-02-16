using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Contacts;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IValidator<Contact> _validator;
        public ContactController(IContactService contactService, IMapper mapper, IValidator<Contact> validator)
        {
            _contactService = contactService;
            _mapper = mapper;
            _validator = validator;
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

            if(result.IsValid)
            {
                await _contactService.TAddAsync(map);
                return RedirectToAction("Index","Contact");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            return RedirectToAction("Index", "Contact");
        }
    }
}
