using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportManager(IReportDal reportDal, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _reportDal = reportDal;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Report>> GetListAsync()
        {
            return await _reportDal.GetAllAsync(x => !x.IsDeleted); // Silinmemis olan haberler
        }
        public async Task<string> TAddReportAndImageAsync(ReportAddDto reportAddDto)
        {
           return await _reportDal.AddReportAndImageAsync(reportAddDto);
        }
        public async Task TAddAsync(Report t)
        {
            await _reportDal.AddAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Report t)
        {
            await _reportDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ReportListDto> TGetAllByPagingAsync(int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            return await _reportDal.GetAllByPagingAsync(currentPage, pageSize, isAscending);
        }

        public async Task<Report> TGetByGuidAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Report>().GetAsync(x => x.Id == id, i => i.Image);
        }

        public async Task<ReportListDto> TSearchAsync(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            return await _reportDal.SearchAsync(keyword, currentPage, pageSize, isAscending);
        }

        public async Task TUpdateAsync(Report t)
        {
            await _reportDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> TUpdateReportAndImageAsync(ReportUpdateDto reportUpdateDto)
        {
            return await _reportDal.UpdateReportAndImageAsync(reportUpdateDto);
        }

        public async Task<string> TSafeDeleteReportAsync(Guid reportId)
        {
            return await _reportDal.SafeDeleteReportAsync(reportId);
        }

        public async Task<string> TUndoDeleteReportAsync(Guid reportId)
        {
            return await _reportDal.UndoDeleteReportAsync(reportId);
        }

        public async Task<List<Report>> GetDeletedListAsync()
        {
            return await _reportDal.GetAllAsync(x => x.IsDeleted); // Silinmis olan haberler
        }
    }
}
