using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class LessonScore:BaseEntity<Guid> // Ogrencinin Ders Notu
    {
        public LessonScore()
        {
            
        }
        public LessonScore(int studentNo, double score1,double score2, double performanceScore, Guid lessonId, Guid userId)
        {
            StudentNo = studentNo;
            Score1 = score1;
            Score2 = score2;
            PerformanceScore = performanceScore;
            LessonId = lessonId;
            UserId = userId;
        }
        public int StudentNo { get; set; } // Ogrencinin numarasi
        public double? Score1 { get; set; } // Dersin 1. puani
        public double? Score2 { get; set; } // Dersin 2. puani
        public double? PerformanceScore { get; set; } // Dersin performans/degerlendirme puani
        public Guid LessonId { get; set; } // Hangi derse ait puan girilecegi bilgisi
        public Lesson Lesson { get; set; }
        public Guid UserId { get; set; } // Hangi ogrenciye ait puan girilecegi bilgisi
        public AppUser User { get; set; }
    }
}
