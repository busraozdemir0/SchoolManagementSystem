using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
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

        public ReportManager(IReportDal reportDal, IUnitOfWork unitOfWork)
        {
            _reportDal = reportDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Report>> GetListAsync()
        {
            return await _reportDal.GetAllAsync();
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

        public async Task<Report> TGetByGuidAsync(Guid id)
        {
            return await _reportDal.GetByGuidAsync(id);
        }

        public async Task TUpdateAsync(Report t)
        {
            await _reportDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
