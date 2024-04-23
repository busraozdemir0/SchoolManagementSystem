using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Message 
    {
        public Message()
        {
            
        }
        public Message(string subject, string content, Guid senderUserId, string senderUserEmail, Guid receiverUserId, string receiverUserEmail)
        {
            Subject = subject;
            Content = content;
            SenderUserId = senderUserId;
            SenderUserEmail = senderUserEmail;
            ReceiverUserId = receiverUserId;
            ReceiverUserEmail = receiverUserEmail;
        }
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false; // Message eger silindiyse cop kutusunda duracak
        public Guid SenderUserId { get; set; }
        public string SenderUserEmail { get; set; }
        public AppUser SenderUser { get; set; }              
        public Guid ReceiverUserId { get; set; }
        public string ReceiverUserEmail { get; set; }
        public AppUser ReceiverUser { get; set; }
        public bool IsRead { get; set; } = false; // Mesajin detayina tiklandiysa okundu bilgisi true olacak.
        public bool IsImportant { get; set; } = false; // Mesajda eger onemli/yildizli iconuna tiklandiysa onemli klasorunde listelenecek.
    }
}
