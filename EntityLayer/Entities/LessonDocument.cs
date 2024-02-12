using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class LessonDocument
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DocumentPath { get; set; }
        public bool IsDeleted { get; set; } = false;  // Status
        public ICollection<Lesson> Lessons { get; set; }

    }
}
