using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Messages
{
    public class MessageAddDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid SenderUserId { get; set; }
        public string SenderUserEmail { get; set; }
        public Guid ReceiverUserId { get; set; }
        public string ReceiverUserEmail { get; set; }
    }
}
