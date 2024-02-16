using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Addresses;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeAddressViewComponent:ViewComponent
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public HomeAddressViewComponent(IAddressService addressService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _addressService = addressService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var address = await _unitOfWork.GetRepository<Address>().GetAllAsync(); // Address tablosunu listele

            var addressFirst = address.First(); // address listesinden ilkini al

            var map = _mapper.Map<AddressDto>(addressFirst); // bu adresi AddressDto'ya map'le

            return View(map);
        }
    }
}
