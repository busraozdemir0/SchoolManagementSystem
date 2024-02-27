using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Grade:BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
