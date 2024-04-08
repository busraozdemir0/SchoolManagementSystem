using EntityLayer.DTOs.LessonVideos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface ILessonVideoService:IGenericService<LessonVideo>
    {
        Task<List<LessonVideo>> TGetAllVideosByLesson(Lesson lesson); // Gelen ders nesnesine gore o derse yuklenmis ders videolari
        Task<List<LessonVideo>> TGetAllVideosByLesson(Guid lessonId); // (Ogrenci panelinde ders videolarini listelemek icin) Ders id'sine gore o derse yuklenmis ders videolari
        Task<string> TAddLessonVideoAsync(LessonVideoAddDto lessonVideoAddDto);
        Task<string> TUpdateLessonVideoAsync(LessonVideoUpdateDto lessonVideoUpdateDto);
        Task<string> TSafeDeleteLessonVideoAsync(Guid lessonVideoId);
        Task<string> TUndoDeleteLessonVideoAsync(Guid lessonVideoId);
    }
}
