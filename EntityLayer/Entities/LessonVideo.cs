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
        public LessonVideo(string title, string videoName, string videoPath)
        {
            Title = title;
            VideoName= videoName;
            VideoPath = videoPath;
        }
        public string Title { get; set; }
        public string VideoName { get; set; }
        public string VideoPath { get; set; }
        public Guid LessonId { get; set; } // O video hangi derse yuklendigi bilgisi
        public Lesson Lesson { get; set; }
    }
}
