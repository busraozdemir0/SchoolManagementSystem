﻿using DataAccessLayer.Repository.Abstract;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReportDal:IRepository<Report>
    {
        Task<ReportListDto> GetAllByPagingAsync(int currentPage=1, int pageSize=6, bool isAscending=false);
        Task<ReportListDto> SearchAsync(string keyword, int currentPage=1, int pageSize=6, bool isAscending=false);
    }
}