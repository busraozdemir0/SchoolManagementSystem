using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class LessonScoreManager : ILessonScoreService
    {
        private readonly ILessonScoreDal _lessonScoreDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public LessonScoreManager(ILessonScoreDal lessonScoreDal, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _lessonScoreDal = lessonScoreDal;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<LessonScore>> GetDeletedListAsync()
        {
            return await _lessonScoreDal.GetAllAsync(x => x.IsDeleted);
        }

        public async Task<List<LessonScore>> GetListAsync()
        {
            return await _lessonScoreDal.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task TAddAsync(LessonScore t)
        {
            var loginTeacherId = _user.GetLoggedInUserId();
            
            var lessonScore = new LessonScore
            {
                StudentNo = t.StudentNo,
                GradeName=t.GradeName,
                Score1 = t.Score1,
                Score2 = t.Score2,
                PerformanceScore = t.PerformanceScore,
                LessonId = t.LessonId,
                UserId = t.UserId,
                CreatedBy = loginTeacherId.ToString() // Giris yapan ve not ekleyen ogretmenin id bilgisi tabloya kaydediliyor
            };

            await _lessonScoreDal.AddAsync(lessonScore);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(LessonScore t)
        {
            await _lessonScoreDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<LessonScore> TGetByGuidAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<LessonScore>().GetByGuidAsync(id);
        }

        public async Task<List<LessonScore>> TGetDeletedListLoginTeacherLessonScore()
        {
            return await _lessonScoreDal.GetDeletedListLoginTeacherLessonScore();
        }

        public async Task<List<LessonScore>> TGetListLoginTeacherLessonScore()
        {
            return await _lessonScoreDal.GetListLoginTeacherLessonScore();
        }

        public async Task TSafeDeleteLessonScoreAsync(Guid lessonScoreId)
        {
            await _lessonScoreDal.SafeDeleteLessonScoreAsync(lessonScoreId);
        }

        public async Task TUndoDeleteLessonScoreAsync(Guid lessonScoreId)
        {
            await _lessonScoreDal.UndoDeleteLessonScoreAsync(lessonScoreId);
        }

        public async Task TUpdateAsync(LessonScore t)
        {
            await _lessonScoreDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
