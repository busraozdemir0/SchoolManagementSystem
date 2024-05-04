using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.SocialMedias;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class SocialMediaListViewComponent:ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaListViewComponent(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMedias = await _socialMediaService.GetListAsync();
            var mapSocialMedias = _mapper.Map<List<SocialMediaListDto>>(socialMedias);
            return View(mapSocialMedias);
        }
    }
}
