using AutoMapper;
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

        public AboutManager(IAboutDal aboutDal, IUnitOfWork unitOfWork)
        {
            _aboutDal = aboutDal;
            _unitOfWork = unitOfWork;
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

        public async Task<string> TGetSchoolNameAsync()
        {
            return await _aboutDal.GetSchoolNameAsync();
        }

        public async Task TUpdateAboutAndImage(AboutUpdateDto aboutUpdateDto)
        {
            await _aboutDal.UpdateAboutAndImage(aboutUpdateDto);
            await _unitOfWork.SaveAsync();
        }

        public async Task TUpdateAsync(About t)
        {
            await _aboutDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
