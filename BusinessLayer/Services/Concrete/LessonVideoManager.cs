using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class LessonVideoManager : ILessonVideoService
    {
        private readonly ILessonVideoDal _lessonVideoDal;
        private readonly IUnitOfWork _unitOfWork;

        public LessonVideoManager(ILessonVideoDal lessonVideoDal, IUnitOfWork unitOfWork)
        {
            _lessonVideoDal = lessonVideoDal;
            _unitOfWork = unitOfWork;
        }

        public Task<List<LessonVideo>> GetDeletedListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<LessonVideo>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task TAddAsync(LessonVideo t)
        {
            throw new NotImplementedException();
        }

        public Task<string> TAddLessonVideoAsync(LessonVideoAddDto lessonVideoAddDto)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(LessonVideo t)
        {
            throw new NotImplementedException();
        }

        public Task<List<LessonVideo>> TGetAllVideosByLesson(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public Task<LessonVideo> TGetByGuidAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<string> TSafeDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            throw new NotImplementedException();
        }

        public Task<string> TUndoDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(LessonVideo t)
        {
            throw new NotImplementedException();
        }
    }
}
