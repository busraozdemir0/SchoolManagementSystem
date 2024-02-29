using DataAccessLayer.Repository.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactDal:IRepository<Contact>
    {
        Task<string> SafeDeleteContactAsync(Guid contactId);
        Task<string> UndoDeleteContactAsync(Guid contactId);
    }
}
