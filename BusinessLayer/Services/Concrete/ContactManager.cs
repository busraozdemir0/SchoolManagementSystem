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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IUnitOfWork _unitOfWork;

        public ContactManager(IContactDal contactDal, IUnitOfWork unitOfWork)
        {
            _contactDal = contactDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Contact>> GetListAsync()
        {
            return await _contactDal.GetAllAsync();
        }

        public async Task TAddAsync(Contact t)
        {
            await _contactDal.AddAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Contact t)
        {
            await _contactDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Contact> TGetByGuidAsync(Guid id)
        {
            return await _contactDal.GetByGuidAsync(id);
        }

        public async Task TUpdateAsync(Contact t)
        {
            await _contactDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
