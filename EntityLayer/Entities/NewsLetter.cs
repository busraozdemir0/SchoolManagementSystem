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
        public string EMail { get; set; }
    }
}
