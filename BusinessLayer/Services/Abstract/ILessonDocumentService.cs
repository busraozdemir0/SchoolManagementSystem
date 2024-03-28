using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface ILessonDocumentService : IGenericService<LessonDocument>
    {
        Task<List<LessonDocument>> TGetAllDocumentsByLesson(Lesson lesson); // Gelen ders nesnesine gore o derse yuklenmis ders materyalleri
        Task<string> TAddLessonDocumentAsync(LessonDocumentAddDto lessonDocumentAddDto);
    }
}
