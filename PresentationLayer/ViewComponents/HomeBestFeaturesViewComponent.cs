using BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeBestFeaturesViewComponent:ViewComponent
    {
        private readonly IAboutService _aboutService;

        public HomeBestFeaturesViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            return View();
        }
    }
}
