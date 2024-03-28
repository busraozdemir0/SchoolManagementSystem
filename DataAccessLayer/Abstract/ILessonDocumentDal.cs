using DataAccessLayer.Repository.Abstract;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ILessonDocumentDal : IRepository<LessonDocument>
    {
        Task<List<LessonDocument>> GetAllDocumentsByLesson(Lesson lesson); // Gelen ders nesnesine gore o derse yuklenmis ders materyalleri
        Task<string> AddLessonDocumentAsync(LessonDocumentAddDto lessonDocumentAddDto);
    }
}
