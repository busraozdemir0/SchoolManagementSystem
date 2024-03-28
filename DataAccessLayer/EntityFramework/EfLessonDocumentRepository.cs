﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using DataAccessLayer.Helpers.Documents;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfLessonDocumentRepository : Repository<LessonDocument>, ILessonDocumentDal
    {
        private readonly IDocumentHelper _documentHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public EfLessonDocumentRepository(AppDbContext context, IDocumentHelper documentHelper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _documentHelper = documentHelper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<LessonDocument>> GetAllDocumentsByLesson(Lesson lesson)
        {
            var loginTeacherId = _user.GetLoggedInUserId();

            // Giris yapan kisinin o derse yukledigi ders dokumanlari
            var documents = await _unitOfWork.GetRepository<LessonDocument>()
                .GetAllAsync(x=>x.CreatedBy==loginTeacherId.ToString() && !x.IsDeleted, l=>l.Lesson, d=>d.Document);

            List<LessonDocument> lessonDocumentsByLesson = new();
            foreach(var document in documents)
            {
                if (document.LessonId == lesson.Id)
                    lessonDocumentsByLesson.Add(document);
            }

            return lessonDocumentsByLesson;
        }
        public async Task<string> AddLessonDocumentAsync(LessonDocumentAddDto lessonDocumentAddDto)
        {
            var loginTeacherId = _user.GetLoggedInUserId();

            if (lessonDocumentAddDto.Document != null) // Eger dokuman secmisse
            {
                // Dokuman yukleme islemleri
                var documentUpload = await _documentHelper.Upload(lessonDocumentAddDto.Title, lessonDocumentAddDto.Document);
                Document document = new(documentUpload.FullName, lessonDocumentAddDto.Document.ContentType);
                await _unitOfWork.GetRepository<Document>().AddAsync(document);

                // Entity Constructure sayesinde Dokuman Entity'si ile beraber ders dokumani olusturduk.
                var lessonDocument = new LessonDocument(lessonDocumentAddDto.Title, 
                    lessonDocumentAddDto.LessonId, document.Id, loginTeacherId.ToString());

                await _unitOfWork.GetRepository<LessonDocument>().AddAsync(lessonDocument);
                await _unitOfWork.SaveAsync();

                return lessonDocument.Title;
            }
            else // Dokuman secmemisse
            {
                var lessonDocument = new LessonDocument()
                {
                    Title = lessonDocumentAddDto.Title,
                    LessonId = lessonDocumentAddDto.LessonId,
                    CreatedBy = loginTeacherId.ToString(),    // Giris yapan yani dokumani yukleyen kisinin id'si
                };
                await _unitOfWork.GetRepository<LessonDocument>().AddAsync(lessonDocument); // ve bu lessonDocument nesnesini kaydet
                await _unitOfWork.SaveAsync();

                return lessonDocument.Title;
            }
        }
    }
}
