using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class LessonScore // Ogrencinin Ders Notu
    {
        public Guid Id { get; set; }
        public double Score1 { get; set; } // Dersin 1. puani
        public double Score2 { get; set; } // Dersin 2. puani
        public double PerformanceScore { get; set; } // Dersin performans/degerlendirme puani
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
