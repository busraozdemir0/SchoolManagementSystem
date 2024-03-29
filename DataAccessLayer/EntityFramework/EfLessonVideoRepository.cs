using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Helpers.Videos;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
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
    public class EfLessonVideoRepository : Repository<LessonVideo>, ILessonVideoDal
    {
        private readonly IVideoHelper _videoHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public EfLessonVideoRepository(AppDbContext context, IVideoHelper videoHelper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _videoHelper = videoHelper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public Task<string> AddLessonVideoAsync(LessonVideoAddDto lessonVideoAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<LessonVideo>> GetAllVideosByLesson(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public Task<string> SafeDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UndoDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            throw new NotImplementedException();
        }
    }
}
