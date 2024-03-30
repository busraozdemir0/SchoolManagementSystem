using AutoMapper;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.LessonVideos
{
    public class LessonVideoProfile:Profile
    {
        public LessonVideoProfile()
        {
            CreateMap<LessonVideo, LessonVideoAddDto>().ReverseMap();
            CreateMap<LessonVideo, LessonVideoUpdateDto>().ReverseMap();
            CreateMap<LessonVideo, LessonVideoListDto>().ReverseMap();
            CreateMap<LessonVideoAddDto, LessonVideoUpdateDto>().ReverseMap();

        }
    }
}
