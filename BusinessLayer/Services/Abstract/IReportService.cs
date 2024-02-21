using DataAccessLayer.Abstract;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IReportService : IGenericService<Report>
    {
        Task<ReportListDto> TGetAllByPagingAsync(int currentPage = 1, int pageSize = 6, bool isAscending = false);
        Task<ReportListDto> TSearchAsync(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = false);
    }
}
