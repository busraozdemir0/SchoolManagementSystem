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
        Task<List<LessonScore>> TGetListLoginTeacherLessonScore();
        Task<List<LessonScore>> TGetDeletedListLoginTeacherLessonScore();
        Task TSafeDeleteLessonScoreAsync(Guid lessonScoreId);
        Task TUndoDeleteLessonScoreAsync(Guid lessonScoreId);

    }
}
