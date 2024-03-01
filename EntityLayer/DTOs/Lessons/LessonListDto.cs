using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Lessons
{
    public class LessonListDto
    {
        public Guid Id { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int LessonCredit { get; set; }
        public int GradeId { get; set; } // Dersin eklenecegi seviye ya da kacinci sinif oldugu bilgisi
        public Grade Grade { get; set; }
        public bool IsDeleted { get; set; }
    }
}
