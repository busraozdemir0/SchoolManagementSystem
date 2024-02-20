using AutoMapper;
using BusinessLayer.AutoMapper.Abouts;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Abouts;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeAboutViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeAboutViewComponent(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _unitOfWork.GetRepository<About>().GetAllAsync();
            var aboutFirst = abouts.First();

            var map = _mapper.Map<AboutDto>(aboutFirst);
            return View(map);
        }
    }
}
