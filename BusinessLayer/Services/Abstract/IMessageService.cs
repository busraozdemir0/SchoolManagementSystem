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
        Task<string> TSafeDeleteReceiverMessageAsync(Guid messageId); // InBox'ta listelenen yani giren kisiye gelen mesajlardan durumunu false yaparak cop kutusuna tasima.
        Task<string> TUndoDeleteReceiverMessageAsync(Guid messageId); // Giren kisiye gelen ve sildigi mesajlardan durumunu true yaparak InBox'a tasima.
        Task<string> TSafeDeleteSenderMessageAsync(Guid messageId); // SendBox'ta listelenen yani giren kisinin baskasina gonderdigi mesajlardan durumunu false yaparak cop kutusuna tasima.
        Task<string> TUndoDeleteSenderMessageAsync(Guid messageId); // Giren kisinin baskasina gonderdigi ve sildigi mesajlardan durumunu true yaparak InBox'a tasima.
        Task<string> THardDeleteReceiverMessageAsync(Guid messageId); // Giren kisiye ait gelen mesajlardan ve o mesaji cop kutusuna attigi mesajlardan ReceiverIsDeleted true yaparak kendi mesajlaşma panelinden kaldırma.
        Task<string> THardDeleteSenderMessageAsync(Guid messageId); // Giren kisinin gonderdigi ve o mesaji cop kutusuna attigi mesajlardan SenderIsDeleted true yaparak kendi mesajlaşma panelinden kaldırma.
        Task<List<Message>> TGetUnreadMessagesByLoginUser(); // Giris yapan kullanicinin mesaj detayina girdigi an mesaj okundu varsayilacak bu metodda ise okunmamış mesajlar listelenecek.
        Task TMakeTheMessageImportant(Guid messageId); // Kullanici inbox'ta listelenen mesajlarda yani kendisine gelen mesajlarda yildiz iconuna tikladigi takdirde mesaj yildizli olacak.
        Task TUndoMakeTheMessageImportant(Guid messageId); // Yildizli olan mesaji geri almak icin metod.
        Task<List<Message>> TGetAllImportantMessages(); // Yildizli mesajlari getir

        // *** Tumunu sil butonlari icin metodlar
        Task THardDeleteTrashBoxAllMessagesAsync(List<Message> messages); // Cop kutusundaki tum mesajlari silme
        Task TSafeDeleteAllMessagesAsync(List<Message> messages); // InBox veya SendBox'taki tum mesajlari silme (sadece status'u false yapma islemi)

    }
}
