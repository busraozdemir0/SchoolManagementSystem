using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeBestFeaturesViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
