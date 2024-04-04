using DataAccessLayer.Repository.Abstract;
using EntityLayer.DTOs.Lessons;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ILessonDal:IRepository<Lesson>
    {
        Task<List<Lesson>> GetAllTeacherLessonsAsync(); // Giren ogretmen kullanicisinin verdigi dersler listeleniyor.
        Task<string> SafeDeleteLessonAsync(Guid lessonId);
        Task<string> UndoDeleteLessonAsync(Guid lessonId);
        Task<List<LessonListDto>> LessonsInTheStudentsGrade(Guid userId);  // Ogrencinin bulundugu siniftaki dersler listelencek (sadece o ogretmenin verdigi dersler)
        Task<List<LessonListDto>> LessonsInTheStudent(List<Lesson> lessons);  // Giris yapan ogrencinin bulundugu siniftaki tum dersler listeleniyor.
    }
}
