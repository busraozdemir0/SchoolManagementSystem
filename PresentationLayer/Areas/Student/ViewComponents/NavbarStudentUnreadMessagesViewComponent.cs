using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Messages;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Student.ViewComponents
{
	public class NavbarStudentUnreadMessagesViewComponent:ViewComponent
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public NavbarStudentUnreadMessagesViewComponent(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			// Mesaj bildirimleri kisminda sadece okunmamis mesajlar listelenecek.
			var unreadMessageList = await _messageService.TGetUnreadMessagesByLoginUser();
            var messages = unreadMessageList.OrderByDescending(x => x.CreatedDate); // Mesajlari tarihe gore azalan bir sekilde sirala

            var mapMessages = _mapper.Map<List<MessageListDto>>(messages);

            ViewBag.UnreadMessagesCount = mapMessages.Count();
			return View(mapMessages);
		}
	}
}
