using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _lessonDocumentDal.GetAllAsync(x=>x.IsDeleted);
        }

        public async Task<List<LessonDocument>> GetListAsync()
        {
            return await _lessonDocumentDal.GetAllAsync(x => !x.IsDeleted);

        }

        public Task TAddAsync(LessonDocument t)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TAddLessonDocumentAsync(LessonDocumentAddDto lessonDocumentAddDto)
        {
            return await _lessonDocumentDal.AddLessonDocumentAsync(lessonDocumentAddDto);
        }

        public Task TDeleteAsync(LessonDocument t)
        {
            throw new NotImplementedException();
        }

        public async Task<LessonDocument> TGetByGuidAsync(Guid id)
        {
            return await _lessonDocumentDal.GetByGuidAsync(id);
        }

        public Task TUpdateAsync(LessonDocument t)
        {
            throw new NotImplementedException();
        }
    }
}
