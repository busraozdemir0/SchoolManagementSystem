using DataAccessLayer.Repository.Abstract;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ILessonVideoDal : IRepository<LessonVideo>
    {
        Task<List<LessonVideo>> GetAllVideosByLesson(Lesson lesson); // Gelen ders nesnesine gore o derse yuklenmis ders videolari
        Task<List<LessonVideo>> GetAllVideosByLesson(Guid lessonId); // (Ogrenci panelinde ders videolarini listelemek icin) Ders id'sine gore o derse yuklenmis ders videolari
        Task<string> AddLessonVideoAsync(LessonVideoAddDto lessonVideoAddDto);
        Task<string> UpdateLessonVideoAsync(LessonVideoUpdateDto lessonVideoUpdateDto);
        Task<string> SafeDeleteLessonVideoAsync(Guid lessonVideoId);
        Task<string> UndoDeleteLessonVideoAsync(Guid lessonVideoId);
    }
}
