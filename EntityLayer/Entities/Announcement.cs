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
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; } // Duyuruyu kim yaptigi bilgisi
        public virtual AppUser User { get; set; }
    }
}
