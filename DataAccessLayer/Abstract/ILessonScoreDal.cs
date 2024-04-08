using DataAccessLayer.Repository.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ILessonScoreDal : IRepository<LessonScore>
    {
        Task<List<LessonScore>> GetListLoginTeacherLessonScore(); // Giris yapan ogretmenin girdigi not bilgileri listelenecek
        Task<List<LessonScore>> GetDeletedListLoginTeacherLessonScore();
        Task<List<LessonScore>> GetListLoginStudentLessonScore(); // Giris yapan ogrencinin not bilgileri listelenecek
        Task SafeDeleteLessonScoreAsync(Guid lessonScoreId);
        Task UndoDeleteLessonScoreAsync(Guid lessonScoreId);
    }
}
