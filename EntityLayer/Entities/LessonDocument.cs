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
        public LessonDocument()
        {
            
        }
        public LessonDocument(string title, string documentName, string documentPath)
        {
            Title = title;
            DocumentName = documentName;
            DocumentPath = documentPath;
        }
        public string Title { get; set; } // O dokumanin yuklendigi konuya ait baslik
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public Guid LessonId { get; set; } // O dokuman hangi derse yuklendigi bilgisi
        public Lesson Lesson { get; set; }

    }
}
