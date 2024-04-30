using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? UserAbout { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public int? StudentNo { get; set; } // Kayitli olacak kullanici ogrenci ise StudentNo girebilecek
        public int? GradeId { get; set; } // Kayitli olacak kullanici ogrenci ise Sinif bilgisini girebilecek
        public Grade Grade { get; set; }
        public Guid? ImageId { get; set; } // Kisinin gorseli Image tablosunda tutulacak.
        public Image Image { get; set; }
        public bool IsDeleted { get; set; } = false; // Kullaniciyi olabilecek hatalarin onune gecmek adina tamamen silmek yerine SafeDelete islemi kullanacagiz.
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<LessonScore> LessonScores { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Message> SenderUserMessages { get; set; }
        public virtual ICollection<Message> ReceiverUserMessages { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
