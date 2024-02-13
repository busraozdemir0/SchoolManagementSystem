using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public Guid UserId { get; set; } // Duyuruyu kim yaptigi bilgisi
        public AppUser Users { get; set; }
    }
}
