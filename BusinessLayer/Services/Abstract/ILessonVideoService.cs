using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.Users;
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
        Task<List<LessonVideo>> TGetAllVideosByLessonId(Guid lessonId); // (Ogrenci panelinde ders videolarini listelemek icin) Ders id'sine gore o derse yuklenmis ders videolari
        Task<string> TAddLessonVideoAsync(LessonVideoAddDto lessonVideoAddDto);
        Task<string> TUpdateLessonVideoAsync(LessonVideoUpdateDto lessonVideoUpdateDto);
        Task<string> TSafeDeleteLessonVideoAsync(Guid lessonVideoId);
        Task<string> TUndoDeleteLessonVideoAsync(Guid lessonVideoId);
        Task TIncreaseTheCountOfViewsOfTheLessonVideo(LessonVideo lessonVideo); // Student panelinde ogrenci videonun detayina basarak o videoyu izlemeye basladigi an
                                                                                // Visitor ve LessonVideoVisitor tablolarina ilgili bilgiler kaydedilecek ve O videonun goruntulenme sayisi bir arttirilacak.
        Task<HashSet<AppUser>> TStudentsWatchingTheLessonVideo(Guid lessonVideoId); // Derse ait ilgili videoyu izleyen ogrenci listesi

        Task<HashSet<LessonVideo>> TLessonVideosByLoginStudent(); // Giris yapan ogrencinin derslerine ait yuklenmis videolar
        Task<HashSet<LessonVideo>> TUnwatchedVideosByLoginStudent(); // Giris yapmis olan ogrencinin izlememis oldugu ders videolari listelenecek.
    }
}
