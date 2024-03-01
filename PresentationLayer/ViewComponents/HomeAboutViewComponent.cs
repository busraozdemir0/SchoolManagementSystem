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
        private readonly IAboutService _aboutService;

        public HomeAboutViewComponent(IMapper mapper, IAboutService aboutService)
        {
            _mapper = mapper;
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _aboutService.GetListAsync();
            var mapAbout = _mapper.Map<AboutDto>(about.First());
            return View(mapAbout);
        }
    }
}
