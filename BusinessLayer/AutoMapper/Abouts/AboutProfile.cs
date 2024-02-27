using AutoMapper;
using EntityLayer.DTOs.Abouts;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Abouts
{
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<About, AboutUpdateDto>().ReverseMap();
        }
    }
}
