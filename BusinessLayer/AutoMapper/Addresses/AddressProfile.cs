using AutoMapper;
using EntityLayer.DTOs.Addresses;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Addresses
{
    public class AddressProfile:Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<AddressUpdateDto, Address>().ReverseMap();
        }
    }
}
