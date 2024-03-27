using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Addresses;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Reflection;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddressController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IAddressService _addressService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<Address> _validator;

        public AddressController(IAddressService addressService, IToastNotification toast, IMapper mapper, IValidator<Address> validator, IAboutService aboutService)
        {
            _addressService = addressService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
            _aboutService = aboutService;
        }
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var addresses = await _addressService.GetListAsync(); // Address tablosunu listele
           var mapAddress = _mapper.Map<AddressUpdateDto>(addresses.First()); // İlk kaydi AddressUpdateDto'ya map'le
            return View(mapAddress);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddressUpdateDto addressUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapAddress = _mapper.Map<Address>(addressUpdateDto);
            var result = await _validator.ValidateAsync(mapAddress);

            if (result.IsValid)
            {
                await _addressService.TUpdateAsync(mapAddress);
                _toast.AddSuccessToastMessage("Adres bilgisi başarıyla güncellendi.", new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Update","Address",new {Area="Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Adres bilgisi güncellenirken bir hata oluştu.", new ToastrOptions { Title = "Başarısız!" });
            }
            return View();
        }
    }
}
