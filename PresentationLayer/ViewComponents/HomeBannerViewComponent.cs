using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeBannerViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
