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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;
        private readonly IUnitOfWork _unitOfWork;

        public SocialMediaManager(ISocialMediaDal socialMediaDal, IUnitOfWork unitOfWork)
        {
            _socialMediaDal = socialMediaDal;
            _unitOfWork = unitOfWork;
        }

        public Task<List<SocialMedia>> GetDeletedListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SocialMedia>> GetListAsync()
        {
            return await _socialMediaDal.GetAllAsync();
        }

        public Task TAddAsync(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public Task<SocialMedia> TGetByGuidAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<SocialMedia> TGetByIdAsync(int id)
        {
            return await _socialMediaDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(SocialMedia t)
        {
            await _socialMediaDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
