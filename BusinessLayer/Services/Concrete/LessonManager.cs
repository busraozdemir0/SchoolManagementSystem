using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;
        private readonly IUnitOfWork _unitOfWork;

        public LessonManager(IUnitOfWork unitOfWork, ILessonDal lessonDal)
        {
            _unitOfWork = unitOfWork;
            _lessonDal = lessonDal;
        }

        public async Task<List<Lesson>> GetDeletedListAsync()
        {
            return await _lessonDal.GetAllAsync(x => x.IsDeleted, g => g.Grade);
        }

        public async Task<List<Lesson>> GetListAsync()
        {
            return await _lessonDal.GetAllAsync(x=>!x.IsDeleted, g=>g.Grade);
        }

        public async Task TAddAsync(Lesson t)
        {
            var lesson = new Lesson
            {
                LessonCode = t.LessonCode,
                LessonName = t.LessonName,
                LessonCredit = t.LessonCredit,
                GradeId = t.GradeId,
            };

            await _lessonDal.AddAsync(lesson);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Lesson t)
        {
            await _lessonDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Lesson> TGetByGuidAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Lesson>().GetAsync(x => x.Id == id, g=>g.Grade);
        }

        public async Task<string> TSafeDeleteLessonAsync(Guid lessonId)
        {
            return await _lessonDal.SafeDeleteLessonAsync(lessonId);
        }

        public async Task<string> TUndoDeleteLessonAsync(Guid lessonId)
        {
            return await _lessonDal.UndoDeleteLessonAsync(lessonId);
        }

        public async Task TUpdateAsync(Lesson t)
        {
            await _lessonDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
