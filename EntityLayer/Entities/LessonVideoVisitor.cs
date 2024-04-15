using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class LessonVideoVisitor
    {
        public LessonVideoVisitor()
        {
            
        }
        public LessonVideoVisitor(Guid lessonVideoId, int visitorId)
        {
            LessonVideoId = lessonVideoId;
            VisitorId = visitorId;
        }

        // Iki adet PK degeri tasiyacak olan tablo (Hem Visitor tablosuyla hem de LessonVideo tablosuyla iliski kurarak coka cok iliskiyi olusturacak)
        public Guid LessonVideoId { get; set; }
        public LessonVideo LessonVideo { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
    }
}
