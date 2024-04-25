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
        public Guid SenderUserId { get; set; }
        public string SenderUserEmail { get; set; }
        public AppUser SenderUser { get; set; }              
        public Guid ReceiverUserId { get; set; }
        public string ReceiverUserEmail { get; set; }
        public AppUser ReceiverUser { get; set; }
        public bool IsRead { get; set; } = false; // Mesajin detayina tiklandiysa okundu bilgisi true olacak.
        public bool IsImportant { get; set; } = false; // Mesajda eger onemli/yildizli iconuna tiklandiysa onemli klasorunde listelenecek.
        public bool SenderStatus { get; set; } = true; // Mesaji gonderen kisinin ilgili mesaji cop kutusuna tasimasi (durumu false olursa cop kutusuna tasinmistir)
        public bool SenderIsDeleted { get; set; } = false; // Mesaji gonderen kisinin ilgili mesaji cop kutusundan da silmesi
        public bool ReceiverStatus { get; set; } = true; // Mesaji alan kisinin ilgili mesaji cop kutusuna tasimasi (durumu false olursa cop kutusuna tasinmistir)
        public bool ReceiverIsDeleted { get; set; } = false; // Mesaji alan kisinin ilgili mesaji cop kutusundan da silmesi
    }
}
