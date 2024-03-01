using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfLessonRepository : Repository<Lesson>, ILessonDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfLessonRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> SafeDeleteLessonAsync(Guid lessonId)
        {
            var lesson = await _unitOfWork.GetRepository<Lesson>().GetAsync(x => x.Id == lessonId);

            lesson.IsDeleted = true;
            lesson.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Lesson>().UpdateAsync(lesson);
            await _unitOfWork.SaveAsync();

            return lesson.LessonName;
        }

        public async Task<string> UndoDeleteLessonAsync(Guid lessonId)
        {
            var lesson = await _unitOfWork.GetRepository<Lesson>().GetAsync(x => x.Id == lessonId);

            lesson.IsDeleted = false;
            lesson.DeletedDate = null;

            await _unitOfWork.GetRepository<Lesson>().UpdateAsync(lesson);
            await _unitOfWork.SaveAsync();

            return lesson.LessonName;
        }
    }
}
