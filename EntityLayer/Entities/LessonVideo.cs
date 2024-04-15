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
        public LessonVideo()
        {
            
        }
        public LessonVideo(string title, Guid lessonId, Guid videoId, string createdBy)
        {
            Title = title;
            LessonId = lessonId;
            VideoId = videoId;
            CreatedBy = createdBy;
        }
        public string Title { get; set; } // O dokumanin yuklendigi konuya ait baslik
        public string? YoutubeVideoPath { get; set; } // Kullanici dilerse Youtube'daki bir videoyu entegre edebilir.
        public Guid? VideoId { get; set; }
        public Video Video { get; set; }
        public Guid LessonId { get; set; } // O dokuman hangi derse yuklendigi bilgisi
        public Lesson Lesson { get; set; }
        public int ViewCount { get; set; } = 0; // Video goruntulenme sayisi (ogrenciler tarafindan video detayina tiklandiginda artacak)
        public ICollection<LessonVideoVisitor> LessonVideoVisitors { get; set; } // Coka cok iliski kurmak icin
        
    }
}
