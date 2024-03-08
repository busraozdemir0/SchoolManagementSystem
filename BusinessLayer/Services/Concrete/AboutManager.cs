using AutoMapper;
using BusinessLayer.Helpers.Images;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Abouts;
using EntityLayer.Entities;
using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        private readonly IMapper _mapper;

        public AboutManager(IAboutDal aboutDal, IUnitOfWork unitOfWork, IImageHelper imageHelper, IMapper mapper)
        {
            _aboutDal = aboutDal;
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            _mapper = mapper;
        }

        public async Task<List<About>> GetDeletedListAsync()
        {
            return await _aboutDal.GetAllAsync(x => x.IsDeleted, i => i.Image);
        }

        public async Task<List<About>> GetListAsync()
        {
            return await _aboutDal.GetAllAsync(x=>!x.IsDeleted, i=>i.Image);
        }

        public Task TAddAsync(About t)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(About t)
        {
            throw new NotImplementedException();
        }

        public Task<About> TGetByGuidAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<About> TGetByIdAsync(int id)
        {
            return await _aboutDal.GetByIdAsync(id);
        }
        public async Task TUpdateAboutAndImage(AboutUpdateDto aboutUpdateDto)
        {
            var about = await _unitOfWork.GetRepository<About>().GetAsync(x => x.Id == aboutUpdateDto.Id, i => i.Image); // Gelen nesneyi id'sine göre cek ve Image tablosunu entegre et

            if (aboutUpdateDto.Photo != null)
            {
                if(aboutUpdateDto.ImageId != null) // Hakkımızda guncelleme sırasında eger ImageId bos degilse var olan resmi sil.
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
            await _unitOfWork.SaveAsync();
        }

        public async Task TUpdateAsync(About t)
        {
            await _aboutDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
