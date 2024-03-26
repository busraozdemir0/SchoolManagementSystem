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
        Task<List<LessonScore>> GetListLoginTeacherLessonScore();
        Task<List<LessonScore>> GetDeletedListLoginTeacherLessonScore();
        Task SafeDeleteLessonScoreAsync(Guid lessonScoreId);
        Task UndoDeleteLessonScoreAsync(Guid lessonScoreId);
    }
}
