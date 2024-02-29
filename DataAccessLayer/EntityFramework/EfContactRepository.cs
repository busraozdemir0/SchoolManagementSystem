using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactRepository : Repository<Contact>, IContactDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfContactRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> SafeDeleteContactAsync(Guid contactId)
        {
            var contact = await _unitOfWork.GetRepository<Contact>().GetByGuidAsync(contactId);

            contact.IsDeleted = true;
            contact.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Contact>().UpdateAsync(contact);
            await _unitOfWork.SaveAsync();

            return contact.Subject;
        }

        public async Task<string> UndoDeleteContactAsync(Guid contactId)
        {
            var contact = await _unitOfWork.GetRepository<Contact>().GetByGuidAsync(contactId);

            contact.IsDeleted = false;
            contact.DeletedDate = null;

            await _unitOfWork.GetRepository<Contact>().UpdateAsync(contact);
            await _unitOfWork.SaveAsync();

            return contact.Subject;
        }
    }
}
