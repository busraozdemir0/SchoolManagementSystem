using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class About: BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
