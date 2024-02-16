using AutoMapper;
using EntityLayer.DTOs.Contacts;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Contacts
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<ContactAddDto, Contact>().ReverseMap();
        }
    }
}
