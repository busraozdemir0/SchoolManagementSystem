using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Messages;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Student.Controllers
{
    [Area("Student")]
    public class MessageController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;
        private readonly IValidator<Message> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public MessageController(IAboutService aboutService, IMessageService messageService, IMapper mapper, IToastNotification toast, IValidator<Message> validator, IUnitOfWork unitOfWork)
        {
            _aboutService = aboutService;
            _messageService = messageService;
            _mapper = mapper;
            _toast = toast;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> InBox()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            // Giris yapan kisiye ait gelen mesajlar listeleniyor
            var inboxMessages = await _messageService.TGetInBoxWithMessageByLoginUser(); // Giris yapan kisinin id bilgisi ile message tablosunda ReceiverUserId esit olan mesajlar listelenecek.
            var mapMessages = _mapper.Map<List<MessageListDto>>(inboxMessages);

            return View(mapMessages);
        }
        public async Task<IActionResult> SendBox()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            // Giris yapan kisinin gonderdigi mesajlar listeleniyor.
            var messages = await _messageService.TGetSendBoxWithMessageByLoginUser(); // Giris yapan kisinin id bilgisi ile message tablosunda SenderUserId esit olan mesajlar listelenecek.
            var mapMessages = _mapper.Map<List<MessageListDto>>(messages);
            ViewBag.sendboxMessageCount = mapMessages.Count();

            return View(mapMessages);
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageAddDto messageAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapMessage = _mapper.Map<Message>(messageAddDto);
            var result = await _validator.ValidateAsync(mapMessage);

            if (result.IsValid)
            {
                var users = await _unitOfWork.GetRepository<AppUser>().GetAllAsync();

                if (users.Any(x => x.Email == messageAddDto.ReceiverUserEmail)) // Eger gonderilmek istenen mail adresine ait AppUser tablosunda mail varsa
                {
                    var receiverUser = await _unitOfWork.GetRepository<AppUser>()
                    .GetAsync(x => x.Email == messageAddDto.ReceiverUserEmail);
                    mapMessage.ReceiverUserId = receiverUser.Id;
                    mapMessage.ReceiverUserEmail = receiverUser.Email;
                    await _messageService.TAddAsync(mapMessage);
                    _toast.AddSuccessToastMessage(Messages.Message.Add(messageAddDto.Subject), new ToastrOptions { Title = "İşlem Başarılı!" });
                    return RedirectToAction("SendBox", "Message", new { Area = "Student" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Göndermek istediğiniz kullanıcı bulunamadı. Lütfen geçerli bir kullanıcı e-maili girin.");
                }
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            return View();
        }
        public async Task<IActionResult> Details(Guid messageId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            ViewBag.messageId = messageId;

            var message = await _messageService.TGetByGuidAsync(messageId);
            var mapMessage = _mapper.Map<MessageListDto>(message);
            return View(mapMessage);
        }

        public async Task<IActionResult> TrashBox()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var deletedMessages = await _messageService.TGetDeletedMessageByLoginUser(); // Giris yapan kisinin id bilgisi ile message tablosunda ReceiverUserId esit oldugu silinmis mesajlar listelenecek.
            var mapDeletedMessages = _mapper.Map<List<MessageListDto>>(deletedMessages);

            ViewBag.trashMessageCount = mapDeletedMessages.Count();
            return View(mapDeletedMessages);
        }
        public async Task<IActionResult> SafeDelete(Guid messageId)
        {
            var message = await _messageService.TSafeDeleteMessageAsync(messageId);
            _toast.AddSuccessToastMessage(Messages.Message.Delete(message), new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("SendBox", "Message", new { Area = "Student" });
        }
        public async Task<IActionResult> UndoDelete(Guid messageId)
        {
            var message = await _messageService.TUndoDeleteMessageAsync(messageId);
            _toast.AddSuccessToastMessage(Messages.Message.UndoDelete(message), new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("SendBox", "Message", new { Area = "Student" });
        }
        public async Task<IActionResult> MakeImportantMessage(Guid messageId) // Mesaji yildizlayacak action
        {
            await _messageService.TMakeTheMessageImportant(messageId);
            _toast.AddSuccessToastMessage("Mesaj başarıyla yıldızlandı.", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("InBox", "Message", new { Area = "Student" });
        }
        public async Task<IActionResult> UndoMakeImportantMessage(Guid messageId) // Mesaji yildizli klasorunden kaldiracak olan action
        {
            await _messageService.TUndoMakeTheMessageImportant(messageId);
            _toast.AddSuccessToastMessage("Mesaj yıldızlı klasöründen kaldırıldı.", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("InBox", "Message", new { Area = "Student" });
        }

        public async Task<IActionResult> GetAllImportant() // Yildizli mesajlarin listelendigi sayfa
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            // Giris yapan kisiye ait ve yildizladigi mesajlar listeleniyor.
            var importantMessages = await _messageService.TGetAllImportantMessages();
            var mapMessages = _mapper.Map<List<MessageListDto>>(importantMessages);

            ViewBag.ImportantMessageCount = mapMessages.Count;
            return View(mapMessages);
        }
    }
}
