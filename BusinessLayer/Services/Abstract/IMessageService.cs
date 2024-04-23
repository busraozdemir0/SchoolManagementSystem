using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task<List<Message>> TGetInBoxWithMessageByLoginUser(); // Giris yapan kullanicinin Gelen Kutusu(yani login olan kullaniciya gonderilen mesajlar).
        Task<List<Message>> TGetSendBoxWithMessageByLoginUser(); // Giris yapan kullanicinin Giden Kutusu(yani login olan kullanicinin gonderdigi mesajlar).
        Task<List<Message>> TGetDeletedMessageByLoginUser(); // Giris yapan kisinin sildigi mesajlar tutulacak.
        Task<string> TSafeDeleteMessageAsync(Guid messageId);
        Task<string> TUndoDeleteMessageAsync(Guid messageId);
        Task<List<Message>> TGetUnreadMessagesByLoginUser(); // Giris yapan kullanicinin mesaj detayina girdigi an mesaj okundu varsayilacak bu metodda ise okunmamış mesajlar listelenecek.
        Task TMakeTheMessageImportant(Guid messageId); // Kullanici inbox'ta listelenen mesajlarda yani kendisine gelen mesajlarda yildiz iconuna tikladigi takdirde mesaj yildizli olacak.
        Task TUndoMakeTheMessageImportant(Guid messageId); // Yildizli olan mesaji geri almak icin metod.
        Task<List<Message>> TGetAllImportantMessages(); // Yildizli mesajlari getir
    }
}
