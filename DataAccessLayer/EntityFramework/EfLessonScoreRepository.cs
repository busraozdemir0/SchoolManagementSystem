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
    public class EfLessonScoreRepository : Repository<LessonScore>, ILessonScoreDal
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IUnitOfWork _unitOfWork;
        public EfLessonScoreRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LessonScore>> GetListLoginTeacherLessonScore()
        {
            // Giris yapan ogretmenin girdigi not bilgileri listelenecek

            var loginTeacherId = _user.GetLoggedInUserId();
            var loginTeacherLessonScores = await _unitOfWork.GetRepository<LessonScore>().
                GetAllAsync(x => x.CreatedBy == loginTeacherId.ToString() && !x.IsDeleted, u => u.User, l => l.Lesson);

            return loginTeacherLessonScores;
        }

        public async Task<List<LessonScore>> GetDeletedListLoginTeacherLessonScore()
        {
            // Giris yapan ogretmenin kaldırdığı not bilgileri listelenecek

            var loginTeacherId = _user.GetLoggedInUserId();
            var loginTeacherLessonScores = await _unitOfWork.GetRepository<LessonScore>().
                GetAllAsync(x => x.CreatedBy == loginTeacherId.ToString() && x.IsDeleted, u => u.User, l => l.Lesson);

            return loginTeacherLessonScores;
        }

        public async Task SafeDeleteLessonScoreAsync(Guid lessonScoreId)
        {
            var lessonScore = await _unitOfWork.GetRepository<LessonScore>().GetAsync(x => x.Id == lessonScoreId);

            lessonScore.IsDeleted = true;
            lessonScore.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<LessonScore>().UpdateAsync(lessonScore);
            await _unitOfWork.SaveAsync();

        }

        public async Task UndoDeleteLessonScoreAsync(Guid lessonScoreId)
        {
            var lessonScore = await _unitOfWork.GetRepository<LessonScore>().GetAsync(x => x.Id == lessonScoreId);

            lessonScore.IsDeleted = false;
            lessonScore.DeletedDate = null;

            await _unitOfWork.GetRepository<LessonScore>().UpdateAsync(lessonScore);
            await _unitOfWork.SaveAsync();
        }
    }
}
