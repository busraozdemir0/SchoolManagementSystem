using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Contacts
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; }=false;
    }
}
