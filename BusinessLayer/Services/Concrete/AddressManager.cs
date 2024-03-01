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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IUnitOfWork _unitOfWork;

        public AddressManager(IAddressDal addressDal, IUnitOfWork unitOfWork)
        {
            _addressDal = addressDal;
            _unitOfWork = unitOfWork;
        }

        public Task<List<Address>> GetDeletedListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Address>> GetListAsync()
        {
            return await _addressDal.GetAllAsync();
        }

        public async Task TAddAsync(Address t)
        {
            await _addressDal.AddAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Address t)
        {
            await _addressDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Address> TGetByGuidAsync(Guid id)
        {
            return await _addressDal.GetByGuidAsync(id);
        }

        public async Task TUpdateAsync(Address t)
        {
            await _addressDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
