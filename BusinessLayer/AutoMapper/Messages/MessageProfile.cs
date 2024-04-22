using AutoMapper;
using EntityLayer.DTOs.Messages;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Messages
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageListDto>().ReverseMap();
            CreateMap<Message, MessageAddDto>().ReverseMap();
        }
    }
}
