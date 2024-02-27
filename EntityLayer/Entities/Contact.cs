using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Contact:BaseEntity<Guid>
    {
        public Contact()
        {
            
        }
        public Contact(string nameSurname, string eMail, string subject, string message)
        {
            NameSurname = nameSurname;
            EMail = eMail;
            Subject = subject;
            Message = message;
        }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
