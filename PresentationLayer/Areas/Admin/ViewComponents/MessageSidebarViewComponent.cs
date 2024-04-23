using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Messages;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class MessageSidebarViewComponent:ViewComponent
    {
        private readonly IMessageService _messageService;

        public MessageSidebarViewComponent(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Giris yapan kisiye ait gelen mesajlardan okunmayanlarin kac adet oldugu bilgisi
            var inboxUnreadMessages = await _messageService.TGetUnreadMessagesByLoginUser(); 
            ViewBag.inboxMessageCount = inboxUnreadMessages.Count(); 

            return View();
        }
    }
}
