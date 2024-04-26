using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Messages;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;
using System.Security.Claims;
using X.PagedList;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MessageController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;
        private readonly IValidator<Message> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public MessageController(IAboutService aboutService, IMessageService messageService, IMapper mapper, IToastNotification toast, IValidator<Message> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _aboutService = aboutService;
            _messageService = messageService;
            _mapper = mapper;
            _toast = toast;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IActionResult> InBox(int page = 1)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            // Giris yapan kisiye ait gelen mesajlar listeleniyor
            var inboxMessages = await _messageService.TGetInBoxWithMessageByLoginUser(); // Giris yapan kisinin id bilgisi ile message tablosunda ReceiverUserId esit olan mesajlar listelenecek.
            var mapMessages = _mapper.Map<List<MessageListDto>>(inboxMessages);

            return View(mapMessages.ToPagedList(page, 10)); // Her sayfada 10 veri olmasi icin sayfalamaislemi yaptik.
        }
        public async Task<IActionResult> SendBox(int page = 1)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            // Giris yapan kisinin gonderdigi mesajlar listeleniyor.
            var messages = await _messageService.TGetSendBoxWithMessageByLoginUser(); // Giris yapan kisinin id bilgisi ile message tablosunda SenderUserId esit olan mesajlar listelenecek.
            var mapMessages = _mapper.Map<List<MessageListDto>>(messages);
            ViewBag.sendboxMessageCount = mapMessages.Count();

            return View(mapMessages.ToPagedList(page, 10));
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
                    return RedirectToAction("SendBox", "Message", new { Area = "Teacher" });
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
            ViewBag.LoginUserId = _user.GetLoggedInUserId(); // Detayina basilan mesaj giren kisinin kendi gonderdigi mesaj mi, yoksa kendisine gelen mesaj mi oldugunu view tarafinda kontrol ettirmek icin

            var message = await _messageService.TGetByGuidAsync(messageId);
            var mapMessage = _mapper.Map<MessageListDto>(message);
            return View(mapMessage);
        }

        public async Task<IActionResult> TrashBox(int page = 1)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            ViewBag.LoginUserId = _user.GetLoggedInUserId(); // Giren kisinin cop kutusunda kendi gonderdigi mesaji mi yoksa kendisine gelen mesaji sildigi kontrolunu view tarafinda yapabilmek icin login olan user id'sini tasiyoruz.

            var deletedMessages = await _messageService.TGetDeletedMessageByLoginUser(); // Giris yapan kisinin id bilgisi ile message tablosunda ReceiverUserId esit oldugu silinmis mesajlar listelenecek.
            var mapDeletedMessages = _mapper.Map<List<MessageListDto>>(deletedMessages);

            ViewBag.trashMessageCount = mapDeletedMessages.Count();
            return View(mapDeletedMessages.ToPagedList(page, 10));
        }

        // *** Tumunu sil butonlari icin action'lar
        public async Task<IActionResult> SafeDeleteAllInBoxMessages() // InBox'ta listelenen mesajlari tumunu sil butonu ile silme
        {
            var inboxMessages = await _messageService.TGetInBoxWithMessageByLoginUser(); // Giris yapan kisiye ait gelen mesajlar listeleniyor
            await _messageService.TSafeDeleteAllMessagesAsync(inboxMessages);
            _toast.AddSuccessToastMessage("Tüm mesajlar başarıyla çöp kutusuna taşındı", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("InBox", "Message", new { Area = "Teacher" });
        }
        public async Task<IActionResult> SafeDeleteAllSendBoxMessages() // SendBox'ta listelenen mesajlari tumunu sil butonu ile silme
        {
            var inboxMessages = await _messageService.TGetSendBoxWithMessageByLoginUser(); // Giris yapan kisinin gonderdigi mesajlar listeleniyor
            await _messageService.TSafeDeleteAllMessagesAsync(inboxMessages);
            _toast.AddSuccessToastMessage("Tüm mesajlar başarıyla çöp kutusuna taşındı", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("SendBox", "Message", new { Area = "Teacher" });
        }
        public async Task<IActionResult> SafeDeleteAllImportantMessages() // Yildizli mesajlarda listelenen mesajlari tumunu sil butonu ile silme
        {
            var inboxMessages = await _messageService.TGetAllImportantMessages(); // Giris yapan kisinin yildizladigi mesajlar
            await _messageService.TSafeDeleteAllMessagesAsync(inboxMessages);
            _toast.AddSuccessToastMessage("Tüm mesajlar başarıyla çöp kutusuna taşındı", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("GetAllImportant", "Message", new { Area = "Teacher" });
        }
        public async Task<IActionResult> HardDeleteAllTrashBox() // Cop kutusundaki listelenen mesajlari tumunu sil butonu ile silme
        {
            var trashboxMessages = await _messageService.TGetDeletedMessageByLoginUser(); // Giris yapan kisinin id bilgisi ile message tablosunda ReceiverUserId esit oldugu silinmis mesajlar listelenecek.
            await _messageService.THardDeleteTrashBoxAllMessagesAsync(trashboxMessages);
            _toast.AddSuccessToastMessage("Tüm mesajlar başarıyla silindi", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("TrashBox", "Message", new { Area = "Teacher" });

        }
        // ***

        public async Task<IActionResult> SafeDeleteInBox(Guid messageId) // Inbox'taki mesajlar giren kisiye gelen mesajlar oldugu icin yani ReceiverUserId ile giris yapanin id'si esit oldugu icin buradaki mesajlara ayri silme islemi uygulaniyor.
        {
            var message = await _messageService.TSafeDeleteReceiverMessageAsync(messageId);
            _toast.AddSuccessToastMessage(Messages.Message.Delete(message), new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("InBox", "Message", new { Area = "Teacher" });
        }
        public async Task<IActionResult> UndoDeleteInbox(Guid messageId)
        {
            var message = await _messageService.TUndoDeleteReceiverMessageAsync(messageId);
            _toast.AddSuccessToastMessage(Messages.Message.UndoDelete(message), new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("TrashBox", "Message", new { Area = "Teacher" });
        }
        // Bu metod ile mesaj DB'den tamamen silinmeyecek ama giren kisinin panelinde de gorunmemesini saglayacak+
        // (Bir mesaji gonderdigimizde o mesaji db'den tamamen kaldirirsak bu sefer alici mesaji gormeden silme ihtimalimiz vardir. Bu da senaryo geregi istedigimiz bir şey degil
        // Bundan dolayi projemizde mesajlasma sistemi icin hic bir mesaji DB'den tamamen silme islemini gerceklestirmiyoruz.)
        [HttpPost]
        public async Task<IActionResult> HardDeleteInbox(Guid messageId)
        {
            var message = await _messageService.THardDeleteReceiverMessageAsync(messageId);
            _toast.AddSuccessToastMessage(message + " konulu mesaj başarıyla silindi.", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("TrashBox", "Message", new { Area = "Teacher" });
        }
        public async Task<IActionResult> SafeDeleteSendBox(Guid messageId) // SendBox'taki mesajlar giren kisinin gonderdigi mesajlar oldugu icin yani SenderUserId ile giris yapanin id'si esit oldugu icin buradaki mesajlara ayri silme islemi uygulaniyor.
        {
            var message = await _messageService.TSafeDeleteSenderMessageAsync(messageId);
            _toast.AddSuccessToastMessage(Messages.Message.Delete(message), new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("SendBox", "Message", new { Area = "Teacher" });
        }
        public async Task<IActionResult> UndoDeleteSendBox(Guid messageId)
        {
            var message = await _messageService.TUndoDeleteSenderMessageAsync(messageId);
            _toast.AddSuccessToastMessage(Messages.Message.UndoDelete(message), new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("TrashBox", "Message", new { Area = "Teacher" });
        }
        [HttpPost]
        public async Task<IActionResult> HardDeleteSendbox(Guid messageId)
        {
            var message = await _messageService.THardDeleteSenderMessageAsync(messageId);
            _toast.AddSuccessToastMessage(message + " konulu mesaj başarıyla silindi.", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("TrashBox", "Message", new { Area = "Teacher" });
        }
        // Yalnizca giren kisiye ait mesajlar yani InBox'ta olan mesajlar yildizlanabilecek.
        public async Task<IActionResult> MakeImportantMessage(Guid messageId) // Mesaji yildizlayacak action
        {
            await _messageService.TMakeTheMessageImportant(messageId);
            _toast.AddSuccessToastMessage("Mesaj başarıyla yıldızlandı.", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("InBox", "Message", new { Area = "Teacher" });
        }
        public async Task<IActionResult> UndoMakeImportantMessage(Guid messageId) // Mesaji yildizli klasorunden kaldiracak olan action
        {
            await _messageService.TUndoMakeTheMessageImportant(messageId);
            _toast.AddSuccessToastMessage("Mesaj yıldızlı klasöründen kaldırıldı.", new ToastrOptions { Title = "İşlem Başarılı!" });
            return RedirectToAction("InBox", "Message", new { Area = "Teacher" });
        }

        public async Task<IActionResult> GetAllImportant(int page = 1) // Yildizli mesajlarin listelendigi sayfa
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            // Giris yapan kisiye ait ve yildizladigi mesajlar listeleniyor.
            var importantMessages = await _messageService.TGetAllImportantMessages();
            var mapMessages = _mapper.Map<List<MessageListDto>>(importantMessages);

            ViewBag.ImportantMessageCount = mapMessages.Count;
            return View(mapMessages.ToPagedList(page, 10));
        }
    }
}
