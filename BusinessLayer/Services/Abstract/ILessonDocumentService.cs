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
        Task<List<LessonDocument>> TGetAllDocumentsByLesson(Guid lessonId); // (Ogrenci panelinde ders videolarini listelemek icin) Ders id'sine gore o derse yuklenmis ders materyalleri
        Task<string> TAddLessonDocumentAsync(LessonDocumentAddDto lessonDocumentAddDto);
        Task<string> TUpdateLessonDocumentAsync(LessonDocumentUpdateDto lessonDocumentUpdateDto);
        Task<string> TSafeDeleteLessonDocumentAsync(Guid lessonDocumentId);
        Task<string> TUndoDeleteLessonDocumentAsync(Guid lessonDocumentId);
    }
}
