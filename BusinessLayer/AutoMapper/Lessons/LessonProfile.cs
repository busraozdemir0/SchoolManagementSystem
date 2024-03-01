using AutoMapper;
using EntityLayer.DTOs.Lessons;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Lessons
{
    public class LessonProfile:Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson,LessonListDto>().ReverseMap();
            CreateMap<Lesson,LessonAddDto>().ReverseMap();
            CreateMap<Lesson,LessonUpdateDto>().ReverseMap();
        }
    }
}
