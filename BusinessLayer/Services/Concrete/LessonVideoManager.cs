using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<LessonVideo>> GetDeletedListAsync()
        {
            return await _lessonVideoDal.GetAllAsync(x => x.IsDeleted, l => l.Lesson, d => d.Video);
        }

        public async Task<List<LessonVideo>> GetListAsync()
        {
            return await _lessonVideoDal.GetAllAsync(x => !x.IsDeleted, l => l.Lesson, d => d.Video);
        }

        public Task TAddAsync(LessonVideo t)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TAddLessonVideoAsync(LessonVideoAddDto lessonVideoAddDto)
        {
            return await _lessonVideoDal.AddLessonVideoAsync(lessonVideoAddDto);
        }
        public async Task TDeleteAsync(LessonVideo t)
        {
            await _lessonVideoDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<LessonVideo>> TGetAllVideosByLesson(Lesson lesson)
        {
            return await _lessonVideoDal.GetAllVideosByLesson(lesson);
        }

        public async Task<List<LessonVideo>> TGetAllVideosByLessonId(Guid lessonId)
        {
            return await _lessonVideoDal.GetAllVideosByLessonId(lessonId);
        }

        public async Task<LessonVideo> TGetByGuidAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<LessonVideo>().
                GetAsync(x => x.Id == id, d => d.Video, l => l.Lesson);
        }

        public async Task TIncreaseTheCountOfViewsOfTheLessonVideo(LessonVideo lessonVideo)
        {
             await _lessonVideoDal.IncreaseTheCountOfViewsOfTheLessonVideo(lessonVideo);
        }

        public async Task<string> TSafeDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            return await _lessonVideoDal.SafeDeleteLessonVideoAsync(lessonVideoId);
        }

        public async Task<HashSet<AppUser>> TStudentsWatchingTheLessonVideo(Guid lessonVideoId)
        {
            return await _lessonVideoDal.StudentsWatchingTheLessonVideo(lessonVideoId);
        }

        public async Task<string> TUndoDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            return await _lessonVideoDal.UndoDeleteLessonVideoAsync(lessonVideoId);
        }

        public Task TUpdateAsync(LessonVideo t)
        {
            throw new NotImplementedException();
        }
        public async Task<string> TUpdateLessonVideoAsync(LessonVideoUpdateDto lessonVideoUpdateDto)
        {
            return await _lessonVideoDal.UpdateLessonVideoAsync(lessonVideoUpdateDto);
        }
    }
}
