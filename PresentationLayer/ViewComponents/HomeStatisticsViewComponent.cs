using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeStatisticsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
