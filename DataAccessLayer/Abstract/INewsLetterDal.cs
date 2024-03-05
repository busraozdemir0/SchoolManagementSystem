using DataAccessLayer.Repository.Abstract;
using EntityLayer.DTOs.NewsLetters;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface INewsLetterDal:IRepository<NewsLetter>
    {
        Task<NewsLetter> GetByIdAsync(int id);
        Task<string> SafeDeleteNewsLetterAsync(int newsLetterId);
        Task<string> UndoDeleteNewsLetterAsync(int newsLetterId);
        void SendingBulkEmails(NewsLetterSendEmailDto newsLetterSendEmailDto, List<NewsLetterDto> Emails);
    }
}
