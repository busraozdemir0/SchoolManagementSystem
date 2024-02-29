using AutoMapper;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Reports
{
    public class ReportsProfile:Profile
    {
        public ReportsProfile()
        {
            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<Report, ReportListDto>().ReverseMap();
            CreateMap<Report, ReportAddDto>().ReverseMap();
            CreateMap<Report, ReportUpdateDto>().ReverseMap();
            CreateMap<ReportUpdateDto, ReportAddDto>().ReverseMap();
        }
    }
}
