using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Lessons;
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

        public async Task<List<Lesson>> TGetAllTeacherLessonsAsync()
        {
            return await _lessonDal.GetAllTeacherLessonsAsync();
        }

        public async Task<List<Lesson>> GetDeletedListAsync()
        {
            return await _lessonDal.GetAllAsync(x => x.IsDeleted, g => g.Grade, u => u.User);
        }

        public async Task<List<Lesson>> GetListAsync()
        {
            return await _lessonDal.GetAllAsync(x => !x.IsDeleted, g => g.Grade, u => u.User);
        }

        public async Task TAddAsync(Lesson t)
        {
            var lesson = new Lesson
            {
                LessonCode = t.LessonCode,
                LessonName = t.LessonName,
                LessonCredit = t.LessonCredit,
                GradeId = t.GradeId,
                UserId = t.UserId
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
            return await _unitOfWork.GetRepository<Lesson>().GetAsync(x => x.Id == id && !x.IsDeleted, g => g.Grade, u => u.User);
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

        public async Task<List<LessonListDto>> TLessonsInTheStudentsGrade(Guid userId)
        {
            return await _lessonDal.LessonsInTheStudentsGrade(userId);
        }

        public async Task<List<LessonListDto>> TLessonsInTheStudent(List<Lesson> lessons)
        {
            return await _lessonDal.LessonsInTheStudent(lessons);
        }
    }
}
