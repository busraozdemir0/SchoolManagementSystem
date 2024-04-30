using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Comment:BaseEntity<Guid>
    {
        public string Content { get; set; }
        public Guid UserId { get; set; } // Yorumu yapan kisinin bilgilerini cekebilmek icin
        public AppUser User { get; set; }
    }
}
