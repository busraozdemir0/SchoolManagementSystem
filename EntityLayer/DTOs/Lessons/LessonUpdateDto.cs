using EntityLayer.DTOs.Grades;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Lessons
{
    public class LessonUpdateDto
    {
        public Guid Id { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int LessonCredit { get; set; }
        public int GradeId { get; set; } 
        public ICollection<GradeDto> Grades { get; set; }
    }
}
