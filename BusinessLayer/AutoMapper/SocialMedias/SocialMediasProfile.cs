using AutoMapper;
using EntityLayer.DTOs.SocialMedias;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.SocialMedias
{
    public class SocialMediasProfile:Profile
    {
        public SocialMediasProfile()
        {
            CreateMap<SocialMedia, SocialMediaListDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();
        }
    }
}
