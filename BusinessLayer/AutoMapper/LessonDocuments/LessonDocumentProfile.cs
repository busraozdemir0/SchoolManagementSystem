using AutoMapper;
using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.LessonDocuments
{
    public class LessonDocumentProfile:Profile
    {
        public LessonDocumentProfile()
        {
            CreateMap<LessonDocument, LessonDocumentAddDto>().ReverseMap();
            CreateMap<LessonDocument, LessonDocumentListDto>().ReverseMap();
        }
    }
}
