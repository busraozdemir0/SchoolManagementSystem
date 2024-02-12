using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class LessonVideo
    {
        public Guid Id { get; set; }
        public string Title  { get; set; }
        public string VideoPath { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Lesson> Lessons { get; set; }
    }
}
