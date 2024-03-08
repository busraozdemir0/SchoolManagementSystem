using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Users
{
    public class UserProfileDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? UserAbout { get; set; }
        public string? Gender { get; set; }
        public int? StudentNo { get; set; } // Kayitli olacak kullanici ogrenci ise StudentNo girebilecek
        public int? GradeId { get; set; } // Kayitli olacak kullanici ogrenci ise Sinif bilgisini girebilecek
        public List<Grade> Grades { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; } // Nullable yapmamizin sebebi => kisi eger parolasini degistermek istemedigi durum icin 
        public IFormFile? Photo { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
