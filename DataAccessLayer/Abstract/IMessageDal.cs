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
        Task<List<Message>> GetUnreadMessagesByLoginUser(); // Giris yapan kullanicinin mesaj detayina girdigi an mesaj okundu varsayilacak bu metodda ise okunmamış mesajlar listelenecek.
        Task MakeTheMessageImportant(Guid messageId); // Kullanici inbox'ta listelenen mesajlarda yani kendisine gelen mesajlarda yildiz iconuna tikladigi takdirde mesaj yildizli olacak.
        Task UndoMakeTheMessageImportant(Guid messageId); // Yildizli olan mesaji geri almak icin metod.
        Task<List<Message>> GetAllImportantMessages(); // Yildizli mesajlari getir

    }
}
