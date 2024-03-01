using EntityLayer.DTOs.Grades;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Lessons
{
    public class LessonAddDto
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int LessonCredit { get; set; }
        public int GradeId { get; set; } = 1; // Dersin eklenecegi seviye ya da kacinci sinif oldugu bilgisi
        public ICollection<GradeDto> Grades { get; set; }
    }
}
