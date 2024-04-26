using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageRepository : Repository<Message>, IMessageDal
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public EfMessageRepository(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<Message>> GetInBoxWithMessageByLoginUser()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            List<Message> loginMessagesUser = await _unitOfWork.GetRepository<Message>()
                                        .GetAllAsync(x => x.ReceiverUserId == loginUserId &&
                                        x.ReceiverStatus == true && x.ReceiverIsDeleted == false, s => s.SenderUser); // Mesaj tablosunda id bilgisi ile giris yapanin id bilgisi esitse o mesajlari InBox'ta listeleyecegiz.
            // Listeleme isleminde eger giren kisi kendisine gelen mesajlarda o mesaji cop kutusuna tasimamissa(x.ReceiverStatus == true) veya Cop kutusunda iken o mesaji tamamen kaldirmamissa(&& x.ReceiverIsDeleted == false) listele
            return loginMessagesUser;
        }

        public async Task<List<Message>> GetSendBoxWithMessageByLoginUser()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            List<Message> loginMessagesUser = await _unitOfWork.GetRepository<Message>()
                                        .GetAllAsync(x => x.SenderUserId == loginUserId &&
                                        x.SenderStatus == true && x.SenderIsDeleted == false, r => r.ReceiverUser); // Mesaj tablosunda id bilgisi ile giris yapanin id bilgisi esitse o mesajlari SendBox'ta listeleyecegiz.

            return loginMessagesUser;
        }

        public async Task<List<Message>> GetDeletedMessageByLoginUser()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            // Mesaj tablosunda Receiver ve Sender id bilgisi ile giris yapanin id bilgisi esitse ve silinmis mesaj ise o mesajlari Cop kutusunda listeleyecegiz.
            List<Message> loginDeletedMessagesUser = await _unitOfWork.GetRepository<Message>()
                    .GetAllAsync(x => x.ReceiverUserId == loginUserId && x.ReceiverStatus == false && x.ReceiverIsDeleted == false
                    || x.SenderUserId == loginUserId && x.SenderStatus == false && x.SenderIsDeleted == false, s => s.SenderUser, r => r.ReceiverUser);

            return loginDeletedMessagesUser;
        }

        // *** Tumunu sil butonlari icin metodlar
        public async Task SafeDeleteAllMessagesAsync(List<Message> messages)// Tumunu sil butonu ile tum mesajlari SafeDelete vasitasiyla silme
        {
            var loginUserId = _user.GetLoggedInUserId();

            // Gelen listeye ait tumunu sil butonu ile her bir mesaji sil (ReceiverStatus==false veya SenderStatus==false yapma islemi)
            foreach (var message in messages)
            {
                if (message.ReceiverUserId == loginUserId)
                    await SafeDeleteReceiverMessageAsync(message.Id);
                else if (message.SenderUserId == loginUserId)
                    await SafeDeleteSenderMessageAsync(message.Id);
            }
        }
        public async Task HardDeleteTrashBoxAllMessagesAsync(List<Message> messages) // Tumunu sil butonu ile tum mesajlari HardDelete vasitasiyla silme
        {
            var loginUserId = _user.GetLoggedInUserId();

            // Gelen listeye ait tumunu sil butonu ile her bir mesaji sil (ReceiverIsDeleted==true veya SenderIsDeleted==true yapma islemi)
            foreach (var message in messages)
            {
                if (message.ReceiverUserId == loginUserId)
                    await HardDeleteReceiverMessageAsync(message.Id);
                else if(message.SenderUserId == loginUserId)
                    await HardDeleteSenderMessageAsync(message.Id);
            }
        }
        // ***

        public async Task<string> SafeDeleteReceiverMessageAsync(Guid messageId) // InBox'taki mesajlarin cop kutusuna tasinmasi
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.ReceiverStatus = false; // InBox'ta giren kisiye ait gelen mesaj durumunu false yaparak cop kutusuna tasiyoruz
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }

        public async Task<string> UndoDeleteReceiverMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.ReceiverStatus = true; // Cop kutusunda giren kisiye ait gelen mesaj durumunu true yaparak cop kutusundan InBox'a geri aliyoruz.
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }
        public async Task<string> SafeDeleteSenderMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.SenderStatus = false; // SendBox'ta giren kisinin baskasina gonderdigi mesaj durumunu false yaparak cop kutusuna tasiyoruz.
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }

        public async Task<string> UndoDeleteSenderMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.SenderStatus = true; // Cop kutusunda giren kisinin baskasina gonderdigi mesaj durumunu true yaparak cop kutusundan InBox'a geri aliyoruz.
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }
        public async Task<string> HardDeleteReceiverMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.ReceiverIsDeleted = true; // Cop kutusunda giren kisiye ait gelen mesajlardan ReceiverIsDeleted alanini true yaparak kendi mesajlasma panelinden kaldiriyoruz.
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }

        public async Task<string> HardDeleteSenderMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.SenderIsDeleted = true; // Cop kutusunda giren kisinin gonderdigi mesajlardan SenderIsDeleted alanini true yaparak kendi mesajlasma panelinden kaldiriyoruz.
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }
        public async Task<List<Message>> GetUnreadMessagesByLoginUser()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            List<Message> loginMessagesUser = await _unitOfWork.GetRepository<Message>()
                                        .GetAllAsync(x => x.ReceiverUserId == loginUserId
                                        && x.IsRead == false && x.ReceiverStatus == true && x.ReceiverIsDeleted == false, r => r.SenderUser, i => i.SenderUser.Image); // Giren kisinin okumadigi yani IsRead bilgisi false olan mesajlari mesaj bildirimleri kisminda listeleyecegiz.

            return loginMessagesUser;
        }

        public async Task MakeTheMessageImportant(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>()
                .GetAsync(x => x.Id == messageId, s => s.SenderUser);
            message.IsImportant = true; // Mesaj onemli mi bilgisi true yapiliyor. Yani mesaj onemli klasorune tasindi.
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();
        }

        public async Task UndoMakeTheMessageImportant(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>()
                .GetAsync(x => x.Id == messageId, s => s.SenderUser);
            message.IsImportant = false; // Mesaj onemli mi bilgisi false yapiliyor. Yani mesaj onemli klasorunden kaldirildi.
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Message>> GetAllImportantMessages() // Giris yapan kisinin kendisine gelen mesajlardan yildizli olanlari listeliyoruz.
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            List<Message> loginMessagesUser = await _unitOfWork.GetRepository<Message>()
                                        .GetAllAsync(x => x.ReceiverUserId == loginUserId
                                        && x.IsImportant == true && x.ReceiverStatus == true && x.ReceiverIsDeleted == false, s => s.SenderUser); // Mesaj tablosunda id bilgisi ile giris yapanin id bilgisi esitse ve mesaj yildizlanmissa o mesajlari Yildizli sayfasinda listeleyecegiz.
            // Listeleme yaparken mesaji alan kisi mesaji cop kutusuna tasimadigi takdirde listelenecek.
            return loginMessagesUser;
        }

    
    }
}
