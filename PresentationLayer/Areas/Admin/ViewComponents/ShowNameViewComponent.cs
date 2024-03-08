using BusinessLayer.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class ShowNameViewComponent:ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ShowNameViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var getLoggedInUserName = _user.GetLoggedInUserName();
            ViewBag.GetLoggedInUserName = getLoggedInUserName;

            return View();
        }
    }
}
