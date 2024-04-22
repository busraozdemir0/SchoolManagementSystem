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
            // Giris yapan kisiye ait gelen mesajlar listeleniyor
            var inboxMessages = await _messageService.TGetInBoxWithMessageByLoginUser(); 
            ViewBag.inboxMessageCount = inboxMessages.Count();

            // Giris yapan kisiye ait gonderilen mesajlar listeleniyor
            var sendboxMessages = await _messageService.TGetSendBoxWithMessageByLoginUser(); 
            ViewBag.sendboxMessageCount = sendboxMessages.Count();

            return View();
        }
    }
}
