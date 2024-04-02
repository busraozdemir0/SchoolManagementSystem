using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Announcement : BaseEntity<Guid>
    {
        public Announcement()
        {
            
        }
        public Announcement(string title, string content, DateTime createdDate)
        {
            Title = title;
            Content = content;
            CreatedDate=createdDate;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? RoleId { get; set; } // Duyuru kimlere yapilacagi bilgisi (Ogretmenler, Ogrenciler, Tümü)
        public virtual AppRole Role { get; set; }
        public Guid UserId { get; set; } // Duyuruyu kim yaptigi bilgisi
        public virtual AppUser User { get; set; }
    }
}
