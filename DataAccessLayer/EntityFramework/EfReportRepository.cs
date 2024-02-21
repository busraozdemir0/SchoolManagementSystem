using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReportRepository : Repository<Report>, IReportDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfReportRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context) // base(context) ile turetilmis sinifin yapici metoduna veritabani baglamini iletiyor.
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize; // Sayfa sayisi 20'den buyuk mu?

            var reports = await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted); // Silinmemis olan haberleri (IsDeleted=false olanlari) getir

            var sortedReports = isAscending
                ? reports.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : reports.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();


            return new ReportListDto
            {
                Reports = sortedReports,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = reports.Count,
                IsAscending = isAscending
            };

        }

        public async Task<ReportListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize; // Sayfa sayisi 20'den buyuk mu?

            var reports = await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted && (x.Title.Contains(keyword)));

            var sortedReports = isAscending
                ? reports.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : reports.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ReportListDto
            {
                Reports = sortedReports,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = reports.Count,
                IsAscending = isAscending
            };
        }
    }
}
