using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface ILessonScoreService : IGenericService<LessonScore>
    {
        Task<List<LessonScore>> TGetListLoginTeacherLessonScore(); // Giris yapan ogretmenin girdigi not bilgileri listelenecek
        Task<List<LessonScore>> TGetDeletedListLoginTeacherLessonScore();
        Task<List<LessonScore>> TGetListLoginStudentLessonScore(); // Giris yapan ogrencinin not bilgileri listelenecek
        Task TSafeDeleteLessonScoreAsync(Guid lessonScoreId);
        Task TUndoDeleteLessonScoreAsync(Guid lessonScoreId);

    }
}
