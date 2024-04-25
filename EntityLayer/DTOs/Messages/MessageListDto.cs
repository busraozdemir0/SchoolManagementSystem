using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Messages
{
    public class MessageListDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid SenderUserId { get; set; }
        public string SenderUserEmail { get; set; }
        public AppUser SenderUser { get; set; }
        public Guid ReceiverUserId { get; set; }
        public string ReceiverUserEmail { get; set; }
        public AppUser ReceiverUser { get; set; }
        public bool IsRead { get; set; } = false; // Mesajin detayina tiklandiysa okundu bilgisi true olacak.
        public bool IsImportant { get; set; } = false; // Mesajda eger onemli/yildizli butonuna tiklandiysa onemli klasorunde listelenecek.
    }
}
