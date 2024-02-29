using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IContactService:IGenericService<Contact>
    {
        Task<string> TSafeDeleteContactAsync(Guid contactId);
        Task<string> TUndoDeleteContactAsync(Guid contactId);
    }
}
