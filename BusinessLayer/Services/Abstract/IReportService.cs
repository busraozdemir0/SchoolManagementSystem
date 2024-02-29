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
        Task<string> TAddReportAndImageAsync(ReportAddDto reportAddDto);
        Task<string> TUpdateReportAndImageAsync(ReportUpdateDto reportUpdateDto);
        Task<string> TSafeDeleteReportAsync(Guid reportId);
        Task<string> TUndoDeleteReportAsync(Guid reportId);
    }
}
