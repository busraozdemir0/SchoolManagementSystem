using AutoMapper;
using BusinessLayer.Helpers.Images;
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
        private readonly IImageHelper _imageHelper;
        private readonly IMapper _mapper;

        public ReportManager(IReportDal reportDal, IUnitOfWork unitOfWork, IImageHelper imageHelper, IMapper mapper)
        {
            _reportDal = reportDal;
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            _mapper = mapper;
        }

        public async Task<List<Report>> GetListAsync()
        {
            return await _reportDal.GetAllAsync(x=>!x.IsDeleted); // Silinmemis olan haberler
        }
        public async Task<string> TAddReportAndImageAsync(ReportAddDto reportAddDto)
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
                await _reportDal.AddAsync(report); // ve bu report nesnesini kaydet
                await _unitOfWork.SaveAsync();

                return report.Title;
            }

            
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
            return await _unitOfWork.GetRepository<Report>().GetAsync(x=>x.Id==id, i => i.Image);
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
            var report = await _unitOfWork.GetRepository<Report>().GetAsync(x => x.Id == reportUpdateDto.Id, i => i.Image);

            if (reportUpdateDto.Photo != null) // Eger bir resim secilmisse
            {
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
