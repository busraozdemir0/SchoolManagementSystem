using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.LessonDocuments
{
    public class LessonDocumentAddDto
    {
        public string Title { get; set; }
        public IFormFile Document { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
