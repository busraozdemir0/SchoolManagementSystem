using AutoMapper;
using EntityLayer.DTOs.News;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Newss
{
    public class NewsProfile:Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDto>().ReverseMap();
        }
    }
}
