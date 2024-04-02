using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.LessonDocuments
{
    public class LessonDocumentListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
        public Guid CreatedBy { get; set; }
        public string LessonDocumentTeacherInfo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
