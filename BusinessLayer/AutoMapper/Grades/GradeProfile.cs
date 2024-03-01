using AutoMapper;
using EntityLayer.DTOs.Grades;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Grades
{
    public class GradeProfile:Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, GradeListDto>().ReverseMap();
            CreateMap<Grade, GradeAddDto>().ReverseMap();
            CreateMap<Grade, GradeUpdateDto>().ReverseMap();
            CreateMap<Grade, GradeDto>().ReverseMap();
        }
    }
}
