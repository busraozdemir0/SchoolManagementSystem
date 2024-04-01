using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public ContactController(IContactService contactService, IMapper mapper, IToastNotification toast, IAboutService aboutService)
        {
            _contactService = contactService;
            _mapper = mapper;
            _toast = toast;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var contacts =await _contactService.GetListAsync();
            var mapContacts=_mapper.Map<List<ContactDto>>(contacts);
            return View(mapContacts);
        }
        public async Task<IActionResult> DeletedContacts()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var contacts = await _contactService.GetDeletedListAsync();
            var mapContacts = _mapper.Map<List<ContactDto>>(contacts);
            return View(mapContacts);
        }
        public async Task<IActionResult> Detail(Guid contactId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var contact = await _contactService.TGetByGuidAsync(contactId);
            var mapContact = _mapper.Map<ContactDto>(contact);
            return View(mapContact);
        }
        public async Task<IActionResult> SafeDelete(Guid contactId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var contact = await _contactService.TSafeDeleteContactAsync(contactId);
            _toast.AddSuccessToastMessage(Messages.Contact.Delete(contact), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Contact", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid contactId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var contact = await _contactService.TUndoDeleteContactAsync(contactId);
            _toast.AddSuccessToastMessage(Messages.Contact.UndoDelete(contact), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedContacts", "Contact", new { Area = "Admin" });
        }
        [HttpPost]
		public async Task<IActionResult> HardDelete(Guid contactId)
		{
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var contact = await _contactService.TGetByGuidAsync(contactId);
			await _contactService.TDeleteAsync(contact);
			_toast.AddSuccessToastMessage("Mesaj tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
			return RedirectToAction("DeletedContacts", "Contact", new { Area = "Admin" });
		}
	}
}
