using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class LessonVideo:BaseEntity<Guid>
    {
        public string Title  { get; set; }
        public string VideoPath { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
