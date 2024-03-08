using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Announcements
{
    public class AnnouncementListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public Guid ReceiverId { get; set; }
        public AppRole Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
