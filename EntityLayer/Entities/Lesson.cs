using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Lesson:BaseEntity<Guid>
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int LessonCredit { get; set; }
        public int GradeId { get; set; } // Dersin eklenecegi seviye ya da kacinci sinif oldugu bilgisi
        public Grade Grade { get; set; }
        public Guid? LessonDocumentId { get; set; }
        public LessonDocument LessonDocument { get; set; }
        public Guid? LessonVideoId { get; set; }
        public LessonVideo LessonVideo { get; set; }
        public Guid? UserId { get; set; } // Bu dersi hangi ogretmenin verdigi bilgisi
        public AppUser User { get; set; }
        public ICollection<LessonScore> LessonScores { get; set; }

    }
}
