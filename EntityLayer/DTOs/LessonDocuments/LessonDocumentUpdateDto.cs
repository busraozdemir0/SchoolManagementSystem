using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.LessonDocuments
{
    public class LessonDocumentUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public Guid? DocumentId { get; set; } // Kullanici yukledigi dokumani guncellemek istemeyebilir bu yuzden nullable yapiyoruz.
        public Document Document { get; set; }
        public IFormFile? Material { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
