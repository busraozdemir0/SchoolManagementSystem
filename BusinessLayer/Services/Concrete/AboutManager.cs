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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IUnitOfWork _unitOfWork;

        public AboutManager(IAboutDal aboutDal, IUnitOfWork unitOfWork)
        {
            _aboutDal = aboutDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<About>> GetListAsync()
        {
            return await _aboutDal.GetAllAsync();
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

        public async Task TUpdateAsync(About t)
        {
            await _aboutDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();

        }
    }
}
