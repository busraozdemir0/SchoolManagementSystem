using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
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
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public async Task<List<Address>> GetListAsync()
        {
            return await _addressDal.GetAllAsync();
        }

        public async Task TAddAsync(Address t)
        {
            await _addressDal.AddAsync(t);
        }

        public async Task TDeleteAsync(Address t)
        {
            await _addressDal.DeleteAsync(t);
        }

        public async Task<Address> TGetByGuidAsync(Guid id)
        {
            return await _addressDal.GetByGuidAsync(id);
        }

        public async Task TUpdateAsync(Address t)
        {
            await _addressDal.UpdateAsync(t);
        }
    }
}
