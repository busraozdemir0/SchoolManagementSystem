using AutoMapper;
using EntityLayer.DTOs.LessonScores;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.LessonScores
{
    public class LessonScoreProfile:Profile
    {
        public LessonScoreProfile()
        {
            CreateMap<LessonScore, LessonScoreAddDto>().ReverseMap();
        }
    }
}
