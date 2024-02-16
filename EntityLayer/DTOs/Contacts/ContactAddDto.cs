using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Contacts
{
    public class ContactAddDto
    {
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
