using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class NewsLetter:BaseEntity<int>
    {
        public NewsLetter()
        {
            
        }
        public NewsLetter(string eMail)
        {
            EMail = eMail;
        }
        public string EMail { get; set; }
    }
}
