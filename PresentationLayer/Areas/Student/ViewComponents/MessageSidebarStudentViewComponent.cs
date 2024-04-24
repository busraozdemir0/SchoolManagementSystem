using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Student.ViewComponents
{
    public class MessageSidebarStudentViewComponent: ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IMessageService _messageService;
        public MessageSidebarStudentViewComponent(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMessageService messageService)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id bilgisi
            var loginUser = await _unitOfWork.GetRepository<AppUser>()
                .GetAsync(x => x.Id == loginUserId, i => i.Image);
            ViewBag.UserNameSurname = loginUser.Name + " " + loginUser.Surname;
            ViewBag.UserEmail = loginUser.Email;
            ViewBag.ImageId = loginUser.ImageId;
            if (loginUser.ImageId is not null)
                ViewBag.Image = loginUser.Image.FileName;
            else
                ViewBag.DefaultImage = "user-avatar-profile.png"; // Eger giris yapan kullanicinin profil fotografi yoksa varsayilan gorsel gelecek.

            // Giris yapan kisiye ait gelen mesajlardan okunmayanlarin kac adet oldugu bilgisi
            var inboxUnreadMessages = await _messageService.TGetUnreadMessagesByLoginUser();
            ViewBag.inboxMessageCount = inboxUnreadMessages.Count();

            return View();
        }
    }
}
