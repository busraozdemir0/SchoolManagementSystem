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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<List<Contact>> GetListAsync()
        {
            return await _contactDal.GetAllAsync();
        }

        public async Task TAddAsync(Contact t)
        {
            await _contactDal.AddAsync(t);
        }

        public async Task TDeleteAsync(Contact t)
        {
            await _contactDal.DeleteAsync(t);
        }

        public async Task<Contact> TGetByGuidAsync(Guid id)
        {
            return await _contactDal.GetByGuidAsync(id);
        }

        public async Task TUpdateAsync(Contact t)
        {
            await _contactDal.UpdateAsync(t);
        }
    }
}
