using AutoMapper;
using EntityLayer.DTOs.NewsLetters;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.NewsLetters
{
    public class NewsLetterProfile:Profile
    {
        public NewsLetterProfile()
        {
            CreateMap<NewsLetter, NewsLetterDto>().ReverseMap();
            CreateMap<NewsLetter, NewsLetterListDto>().ReverseMap();
        }
    }
}
