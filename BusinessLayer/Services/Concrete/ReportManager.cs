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
            return await _reportDal.GetAllAsync();
        }

        public async Task TAddAsync(Report t)
        {
            var reportAddDto = _mapper.Map<ReportAddDto>(t); // Gelen Report nesnesini Dto'ya mapleme islemi

            // Resim yukleme islemleri
            var imageUpload = await _imageHelper.Upload(reportAddDto.Title, reportAddDto.Image, ImageType.Post);
            Image image = new(imageUpload.FullName, reportAddDto.Image.ContentType);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            // Entity Constructure sayesinde resmiyle beraber Haber olusturduk.
            var report = new Report(reportAddDto.Title, reportAddDto.Content, image.Id);

            await _unitOfWork.GetRepository<Report>().AddAsync(report);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Report t)
        {
            await _reportDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ReportListDto> TGetAllByPagingAsync(int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            return await _reportDal.GetAllByPagingAsync(currentPage,pageSize,isAscending);
        }

        public async Task<Report> TGetByGuidAsync(Guid id)
        {
            return await _reportDal.GetByGuidAsync(id);
        }

        public async Task<ReportListDto> TSearchAsync(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            return await _reportDal.SearchAsync(keyword,currentPage,pageSize,isAscending);
        }

        public async Task TUpdateAsync(Report t)
        {
            var reportUpdateDto = _mapper.Map<ReportUpdateDto>(t); // Once gelen Report nesnesini Dto'ya esliyoruz
            
            var report = await _unitOfWork.GetRepository<Report>().GetAsync(x=>x.Id==reportUpdateDto.Id, i=>i.Image);

            if (reportUpdateDto.Image != null) // Eger bir resim secilmisse
            {
                _imageHelper.Delete(report.Image.FileName); // Once haber'de var olan resmi silecek

                // Ardindan yeni bir image yukleme islemi
                var imageUpload = await _imageHelper.Upload(reportUpdateDto.Title,reportUpdateDto.Image,ImageType.Post);
                Image image = new(imageUpload.FullName, reportUpdateDto.Image.ContentType);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                report.ImageId = image.Id;
            }

            report.Title = reportUpdateDto.Title;
            report.Content = reportUpdateDto.Content;
            report.ModifiedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Report>().UpdateAsync(report);
            await _unitOfWork.SaveAsync();
        }
    }
}
