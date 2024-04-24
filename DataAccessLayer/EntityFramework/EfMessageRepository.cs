﻿using DataAccessLayer.Abstract;
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
                                        .GetAllAsync(x => x.ReceiverUserId == loginUserId && x.IsDeleted == false, s => s.SenderUser); // Mesaj tablosunda id bilgisi ile giris yapanin id bilgisi esitse o mesajlari InBox'ta listeleyecegiz.

            return loginMessagesUser;
        }

        public async Task<List<Message>> GetSendBoxWithMessageByLoginUser()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            List<Message> loginMessagesUser = await _unitOfWork.GetRepository<Message>()
                                        .GetAllAsync(x => x.SenderUserId == loginUserId && x.IsDeleted == false, r => r.ReceiverUser); // Mesaj tablosunda id bilgisi ile giris yapanin id bilgisi esitse o mesajlari SendBox'ta listeleyecegiz.

            return loginMessagesUser;
        }

        public async Task<List<Message>> GetDeletedMessageByLoginUser()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            // Mesaj tablosunda Receiver ve Sender id bilgisi ile giris yapanin id bilgisi esitse ve silinmis mesaj ise o mesajlari Cop kutusunda listeleyecegiz.
            List<Message> loginDeletedMessagesUser = await _unitOfWork.GetRepository<Message>()
                    .GetAllAsync(x => x.ReceiverUserId == loginUserId && x.IsDeleted == true, s => s.SenderUser);

            return loginDeletedMessagesUser;
        }

        public async Task<string> SafeDeleteMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.IsDeleted = true;
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }

        public async Task<string> UndoDeleteMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.GetRepository<Message>().GetAsync(x => x.Id == messageId);

            message.IsDeleted = false;
            await _unitOfWork.GetRepository<Message>().UpdateAsync(message);
            await _unitOfWork.SaveAsync();

            return message.Subject;
        }

        public async Task<List<Message>> GetUnreadMessagesByLoginUser()
        {
            var loginUserId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si

            List<Message> loginMessagesUser = await _unitOfWork.GetRepository<Message>()
                                        .GetAllAsync(x => x.ReceiverUserId == loginUserId && x.IsDeleted == false
                                        && x.IsRead == false, r => r.SenderUser, i => i.SenderUser.Image); // Giren kisinin okumadigi yani IsRead bilgisi false olan mesajlari mesaj bildirimleri kisminda listeleyecegiz.

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
                                        .GetAllAsync(x => x.ReceiverUserId == loginUserId && x.IsDeleted == false 
                                        && x.IsImportant == true, s => s.SenderUser); // Mesaj tablosunda id bilgisi ile giris yapanin id bilgisi esitse ve mesaj yildizlanmissa o mesajlari Yildizli sayfasinda listeleyecegiz.

            return loginMessagesUser;
        }
    }
}
