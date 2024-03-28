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
        Task<string> TAddLessonDocumentAsync(LessonDocumentAddDto lessonDocumentAddDto);
    }
}
