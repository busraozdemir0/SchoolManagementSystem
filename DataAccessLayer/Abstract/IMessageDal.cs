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
        Task<string> SafeDeleteReceiverMessageAsync(Guid messageId); // InBox'ta listelenen yani giren kisiye gelen mesajlardan durumunu false yaparak cop kutusuna tasima.
        Task<string> UndoDeleteReceiverMessageAsync(Guid messageId); // Giren kisiye gelen ve sildigi mesajlardan durumunu true yaparak InBox'a tasima.
        Task<string> SafeDeleteSenderMessageAsync(Guid messageId); // SendBox'ta listelenen yani giren kisinin baskasina gonderdigi mesajlardan durumunu false yaparak cop kutusuna tasima.
        Task<string> UndoDeleteSenderMessageAsync(Guid messageId); // Giren kisinin baskasina gonderdigi ve sildigi mesajlardan durumunu true yaparak InBox'a tasima.
        Task<string> HardDeleteReceiverMessageAsync(Guid messageId); // Giren kisiye ait gelen mesajlardan ve o mesaji cop kutusuna attigi mesajlardan ReceiverIsDeleted true yaparak kendi mesajlaşma panelinden kaldırma.
        Task<string> HardDeleteSenderMessageAsync(Guid messageId); // Giren kisinin gonderdigi ve o mesaji cop kutusuna attigi mesajlardan SenderIsDeleted true yaparak kendi mesajlaşma panelinden kaldırma.
        Task<List<Message>> GetUnreadMessagesByLoginUser(); // Giris yapan kullanicinin mesaj detayina girdigi an mesaj okundu varsayilacak bu metodda ise okunmamış mesajlar listelenecek.
        Task MakeTheMessageImportant(Guid messageId); // Kullanici inbox'ta listelenen mesajlarda yani kendisine gelen mesajlarda yildiz iconuna tikladigi takdirde mesaj yildizli olacak.
        Task UndoMakeTheMessageImportant(Guid messageId); // Yildizli olan mesaji geri almak icin metod.
        Task<List<Message>> GetAllImportantMessages(); // Yildizli mesajlari getir

        // *** Tumunu sil butonlari icin metodlar
        Task HardDeleteTrashBoxAllMessagesAsync(List<Message> messages); // Cop kutusundaki tum mesajlari silme
        Task SafeDeleteAllMessagesAsync(List<Message> messages); // InBox veya SendBox'taki tum mesajlari silme (sadece status'u false yapma islemi)

    }
}
