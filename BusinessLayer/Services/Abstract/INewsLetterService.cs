using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface INewsLetterService : IGenericService<NewsLetter>
    {
        Task<NewsLetter> TGetByIdAsync(int id);
        Task<string> TSafeDeleteNewsLetterAsync(int newsLetterId);
        Task<string> TUndoDeleteNewsLetterAsync(int newsLetterId);
    }
}
