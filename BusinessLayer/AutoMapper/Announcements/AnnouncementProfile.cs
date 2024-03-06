using AutoMapper;
using EntityLayer.DTOs.Announcements;
using EntityLayer.Entities;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Announcements
{
    public class AnnouncementProfile:Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Announcement, AnnouncementListDto>().ReverseMap();
            CreateMap<Announcement, AnnouncementAddDto>().ReverseMap();
            CreateMap<Announcement, AnnouncementUpdateDto>().ReverseMap();
        }
    }
}
