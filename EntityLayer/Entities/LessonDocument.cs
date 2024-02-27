using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class LessonDocument:BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string DocumentPath { get; set; }
        public ICollection<Lesson> Lessons { get; set; }

    }
}
