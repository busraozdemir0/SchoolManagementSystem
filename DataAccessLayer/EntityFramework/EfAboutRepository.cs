using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Helpers.Images;
using DataAccessLayer.Repository.Abstract;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Abouts;
using EntityLayer.Entities;
using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutRepository : Repository<About>, IAboutDal
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        public EfAboutRepository(AppDbContext context, IUnitOfWork unitOfWork, IImageHelper imageHelper) : base(context)
        {
            _appDbContext = context;
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _appDbContext.Abouts.FindAsync(id);
        }

        public async Task UpdateAboutAndImage(AboutUpdateDto aboutUpdateDto)
        {
            var about = await _unitOfWork.GetRepository<About>().GetAsync(x => x.Id == aboutUpdateDto.Id, i => i.Image); // Gelen nesneyi id'sine göre cek ve Image tablosunu entegre et

            if (aboutUpdateDto.Photo != null)
            {
                if (aboutUpdateDto.ImageId != null) // Hakkımızda guncelleme sırasında eger ImageId bos degilse var olan resmi sil.
                    _imageHelper.Delete(about.Image.FileName);  // Once about tablosunda var olan resmi silecek
                                                                // Ardindan yeni resim yukleme islemleri

                var imageUpload = await _imageHelper.Upload(aboutUpdateDto.Title, aboutUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, aboutUpdateDto.Photo.ContentType);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                about.ImageId = image.Id;
            }

            about.Title = aboutUpdateDto.Title;
            about.Content = aboutUpdateDto.Content;

            await _unitOfWork.GetRepository<About>().UpdateAsync(about);
        }
    }
}
