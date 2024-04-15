using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Visitor
    {
        public Visitor()
        {
            
        }
        public Visitor(Guid userId, string ipAddress, string userAgent)
        {
            UserId = userId;
            IpAddress = ipAddress;
            UserAgent = userAgent;
        }
        public int Id { get; set; }
        public Guid UserId { get; set; } // Visitor tablosuna eklenen kullanicinin id'si
        public string IpAddress { get; set; } // Tabloya eklenen kullanicinin ip adresi
        public string UserAgent { get; set; } // Giren kullanicinin tarayici turu, surumu ve isletim sistemi gibi bilgileri alir.
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<LessonVideoVisitor> LessonVideoVisitor { get; set; } // Coka cok iliski kurmak icin
    }
}
