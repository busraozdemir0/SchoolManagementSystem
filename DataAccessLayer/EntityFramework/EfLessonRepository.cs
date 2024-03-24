using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfLessonRepository : Repository<Lesson>, ILessonDal
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public EfLessonRepository(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<Lesson>> GetAllTeacherLessonsAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var lessons = await _unitOfWork.GetRepository<Lesson>()
                .GetAllAsync(x => x.UserId == userId, u => u.User, g => g.Grade);

            return lessons.OrderBy(x=>x.Grade.Name).ToList(); // Sinif adina gore artan bicimde sirali olarak donduruluyor.
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
