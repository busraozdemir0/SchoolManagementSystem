using DataAccessLayer.Repository.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IRepository<Message>
    {
        Task<List<Message>> GetInBoxWithMessageByLoginUser(); // Giris yapan kullanicinin Gelen Kutusu(yani login olan kullaniciya gonderilen mesajlar).
        Task<List<Message>> GetSendBoxWithMessageByLoginUser(); // Giris yapan kullanicinin Giden Kutusu(yani login olan kullanicinin gonderdigi mesajlar).
        Task<List<Message>> GetDeletedMessageByLoginUser(); // Giris yapan kisinin sildigi mesajlar tutulacak.
        Task<string> SafeDeleteMessageAsync(Guid messageId);
        Task<string> UndoDeleteMessageAsync(Guid messageId);
    }
}
