using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Lütfen yeni şifrenizi giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
    }
}
