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
        public LessonDocument(string title, Guid lessonId, Guid documentId, string createdBy)
        {
            Title = title;
            LessonId= lessonId;
            DocumentId = documentId;
            CreatedBy = createdBy;
        }
        public string Title { get; set; } // O dokumanin yuklendigi konuya ait baslik
        public Guid LessonId { get; set; } // O dokuman hangi derse yuklendigi bilgisi
        public Lesson Lesson { get; set; }
        public Guid? DocumentId { get; set; }
        public Document Document { get; set; }

    }
}
