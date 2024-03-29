using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonDocuments;
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
    public class LessonDocumentManager : ILessonDocumentService
    {
        private readonly ILessonDocumentDal _lessonDocumentDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonDocumentManager(ILessonDocumentDal lessonDocumentDal, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _lessonDocumentDal = lessonDocumentDal;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LessonDocument>> GetDeletedListAsync()
        {
            return await _lessonDocumentDal.GetAllAsync(x=>x.IsDeleted, l=>l.Lesson, d=>d.Document);
        }

        public async Task<List<LessonDocument>> GetListAsync()
        {
            return await _lessonDocumentDal.GetAllAsync(x => !x.IsDeleted, l => l.Lesson, d => d.Document);

        }

        public Task TAddAsync(LessonDocument t)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TAddLessonDocumentAsync(LessonDocumentAddDto lessonDocumentAddDto)
        {
            return await _lessonDocumentDal.AddLessonDocumentAsync(lessonDocumentAddDto);
        }

        public async Task TDeleteAsync(LessonDocument t)
        {
            await _lessonDocumentDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<LessonDocument>> TGetAllDocumentsByLesson(Lesson lesson)
        {
            return await _lessonDocumentDal.GetAllDocumentsByLesson(lesson);
        }

        public async Task<LessonDocument> TGetByGuidAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<LessonDocument>().
                GetAsync(x => x.Id == id, d => d.Document, l=>l.Lesson);
        }

        public Task<string> TSafeDeleteLessonDocumentAsync(Guid lessonDocumentId)
        {
            return _lessonDocumentDal.SafeDeleteLessonDocumentAsync(lessonDocumentId);
        }

        public Task<string> TUndoDeleteLessonDocumentAsync(Guid lessonDocumentId)
        {
            return _lessonDocumentDal.UndoDeleteLessonDocumentAsync(lessonDocumentId);
        }

        public Task TUpdateAsync(LessonDocument t)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TUpdateLessonDocumentAsync(LessonDocumentUpdateDto lessonDocumentUpdateDto)
        {
            return await _lessonDocumentDal.UpdateLessonDocumentAsync(lessonDocumentUpdateDto);
        }
    }
}
