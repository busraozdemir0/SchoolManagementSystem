using AutoMapper;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Addresses;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeCallBlockViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeCallBlockViewComponent(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var address = await _unitOfWork.GetRepository<Address>().GetAllAsync();

            var addressFirst = address.First(); 
            var map = _mapper.Map<AddressDto>(addressFirst); 

            return View(map);
        }
    }
}
