using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Helpers.Images;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataAccessLayer.EntityFramework
{
    public class EfReportRepository : Repository<Report>, IReportDal
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        public EfReportRepository(AppDbContext context, IUnitOfWork unitOfWork, IImageHelper imageHelper) : base(context) // base(context) ile turetilmis sinifin yapici metoduna veritabani baglamini iletiyor.
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
        }
        public async Task<ReportListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize; // Sayfa sayisi 20'den buyuk mu?

            var reports = await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted,i=>i.Image); 
            // Silinmemis olan haberleri (IsDeleted=false olanlari) getir

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

        public async Task<string> SafeDeleteReportAsync(Guid reportId)
        {
            var report= await _unitOfWork.GetRepository<Report>().GetByGuidAsync(reportId);

            report.IsDeleted = true;
            report.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Report>().UpdateAsync(report);
            await _unitOfWork.SaveAsync();

            return report.Title;
        }

        public async Task<string> UndoDeleteReportAsync(Guid reportId)
        {
            var report = await _unitOfWork.GetRepository<Report>().GetByGuidAsync(reportId);

            report.IsDeleted = false;
            report.DeletedDate = null;

            await _unitOfWork.GetRepository<Report>().UpdateAsync(report);
            await _unitOfWork.SaveAsync();

            return report.Title;
        }

        public async Task<string> AddReportAndImageAsync(ReportAddDto reportAddDto)
        {
            if (reportAddDto.Image != null) // Eger resim secmisse
            {
                // Resim yukleme islemleri
                var imageUpload = await _imageHelper.Upload(reportAddDto.Title, reportAddDto.Image, ImageType.Post);
                Image image = new(imageUpload.FullName, reportAddDto.Image.ContentType);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                // Entity Constructure sayesinde resmiyle beraber Haber olusturduk.
                var report = new Report(reportAddDto.Title, reportAddDto.Content, image.Id);

                await _unitOfWork.GetRepository<Report>().AddAsync(report);
                await _unitOfWork.SaveAsync();

                return report.Title;
            }
            else // Resim secmemisse
            {
                var report = new Report() // Resim haricindeki alanlari report nesnesine aktar
                {
                    Title = reportAddDto.Title,
                    Content = reportAddDto.Content,
                };
                await _unitOfWork.GetRepository<Report>().AddAsync(report); // ve bu report nesnesini kaydet
                await _unitOfWork.SaveAsync();

                return report.Title;
            }
        }

        public async Task<string> UpdateReportAndImageAsync(ReportUpdateDto reportUpdateDto)
        {
            var report = await _unitOfWork.GetRepository<Report>().GetAsync(x => x.Id == reportUpdateDto.Id, i => i.Image);

            if (reportUpdateDto.Photo != null) // Eger bir resim secilmisse
            {
                if (reportUpdateDto.ImageId != null) // Eger haber guncelleme sirasında ImageId bos degilse yani bir resim varsa o resmi silecegiz.
                    _imageHelper.Delete(report.Image.FileName); // Once haber'de var olan resmi silecek

                // Ardindan yeni bir image yukleme islemi
                var imageUpload = await _imageHelper.Upload(reportUpdateDto.Title, reportUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, reportUpdateDto.Photo.ContentType);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                report.ImageId = image.Id;
            }

            report.Title = reportUpdateDto.Title;
            report.Content = reportUpdateDto.Content;
            report.ModifiedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Report>().UpdateAsync(report);
            await _unitOfWork.SaveAsync();

            return report.Title;
        }

    }
}
