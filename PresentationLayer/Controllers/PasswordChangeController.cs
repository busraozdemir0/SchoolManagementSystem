using BusinessLayer.Services.Abstract;
using EntityLayer.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAboutService _aboutService;

        public PasswordChangeController(UserManager<AppUser> userManager, IAboutService aboutService)
        {
            _userManager = userManager;
            _aboutService = aboutService;
        }

        // Giris yaparken sifremi unuttum linkine tiklandiginda calisacak olan action'lar
        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail); // Sifre degisiklik talebi gonderilecek mail (kullanicinin girdigi mail)

            if (user is not null)
            {
                string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new   // Sifremi unuttum kismina bastiginda PasswordChange/ResetPasword sayfasina gidecek.
                {
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme);

                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("Okul Yönetimi", "atlaskolej@gmail.com"); // Mail gönderenin bilgileri
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress(user.Name + " " + user.Surname, forgetPasswordViewModel.Mail);  // Maili alacak olanın bilgileri
                mimeMessage.To.Add(mailboxAddressTo);

                mimeMessage.Subject = "Şifre Değişiklik Talebi";  // Mailin konusu

                var bodyBuilder = new BodyBuilder();  // Mailin icerik kısmı
                bodyBuilder.TextBody = passwordResetTokenLink;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false); // Mailin port numarasi 587
                client.Authenticate("atlaskolej@gmail.com", "kojl dxtu qrwf uxme"); // Mail hesabindaki uygulama sifreleri kismina girerek aldigimiz kod
                client.Send(mimeMessage);
                client.Disconnect(true);

                return Json(new { success = true });
            }
            else // Eger girilen e-mail sistemde yoksa view tarafinda hata mesaji gosterecegiz.
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userID, string token)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            TempData["userID"] = userID;
            TempData["token"] = token;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userID = TempData["userID"];
            var token = TempData["token"];
            if (userID == null || token == null)
            {
                // Hata mesaji
            }
            var user = await _userManager.FindByIdAsync(userID.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded) // Sifre basarili ile degistiyse tekrar giris yapmasi istenecek.
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
