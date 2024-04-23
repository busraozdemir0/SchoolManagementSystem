﻿using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Messages;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class NavbarUnreadMessagesViewComponent:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public NavbarUnreadMessagesViewComponent(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Mesaj bildiirmleri kısmında sadece okunmamis mesajlar listelenecek.
            var unreadMessageList = await _messageService.TGetUnreadMessagesByLoginUser();
            var mapMessages = _mapper.Map<List<MessageListDto>>(unreadMessageList);
            
            ViewBag.UnreadMessagesCount = mapMessages.Count();
            return View(mapMessages);
        }
    }
}
