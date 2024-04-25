using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public MessageManager(IMessageDal messageDal, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _messageDal = messageDal;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<Message>> GetDeletedListAsync()
        {
            return await _messageDal
                .GetAllAsync(/*x => x.IsDeleted == true*/); // Cop kutusunda listelemek icin silinmis olan mesajlari(IsDeleted bilgisi true olanlari) listeliyoruz.
        }

        public async Task<List<Message>> GetListAsync()
        {
            return await _messageDal
                .GetAllAsync(/*x => x.IsDeleted == true*/);
        }

        public async Task TAddAsync(Message t)
        {
            Message message = new()
            {
                Subject = t.Subject,
                Content = t.Content,
                SenderUserId = _user.GetLoggedInUserId(), // Giren kisinin id'si
                SenderUserEmail=_user.GetLoggedInEmail(), // Giren kisinin e-mail'i
                ReceiverUserId=t.ReceiverUserId,
                ReceiverUserEmail=t.ReceiverUserEmail,
            };
            await _messageDal.AddAsync(message);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Message t)
        {
            await _messageDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Message>> TGetAllImportantMessages()
        {
            return await _messageDal.GetAllImportantMessages();
        }

        public async Task<Message> TGetByGuidAsync(Guid id)
        {
            var message = await _messageDal.GetByGuidAsync(id);
            message.IsRead = true; // Mesaj detay sayfasina gidildiginde mesa okundu bilgisi true olacak
            await _messageDal.UpdateAsync(message);
            await _unitOfWork.SaveAsync();
            return message;
        }

        public async Task<List<Message>> TGetDeletedMessageByLoginUser()
        {
            return await _messageDal.GetDeletedMessageByLoginUser();
        }

        public async Task<List<Message>> TGetInBoxWithMessageByLoginUser()
        {
            return await _messageDal.GetInBoxWithMessageByLoginUser();
        }

        public async Task<List<Message>> TGetSendBoxWithMessageByLoginUser()
        {
            return await _messageDal.GetSendBoxWithMessageByLoginUser();
        }

        public async Task<List<Message>> TGetUnreadMessagesByLoginUser()
        {
            return await _messageDal.GetUnreadMessagesByLoginUser();
        }    

        public async Task TMakeTheMessageImportant(Guid messageId)
        {
            await _messageDal.MakeTheMessageImportant(messageId);
        }

        public async Task<string> TSafeDeleteReceiverMessageAsync(Guid messageId)
        {
            return await _messageDal.SafeDeleteReceiverMessageAsync(messageId);
        }

        public async Task<string> TSafeDeleteSenderMessageAsync(Guid messageId)
        {
            return await _messageDal.SafeDeleteSenderMessageAsync(messageId);
        }

        public async Task<string> TUndoDeleteReceiverMessageAsync(Guid messageId)
        {
            return await _messageDal.UndoDeleteReceiverMessageAsync(messageId);
        }

        public async Task<string> TUndoDeleteSenderMessageAsync(Guid messageId)
        {
            return await _messageDal.UndoDeleteSenderMessageAsync(messageId);
        }
        public async Task<string> THardDeleteReceiverMessageAsync(Guid messageId)
        {
            return await _messageDal.HardDeleteReceiverMessageAsync(messageId);
        }

        public async Task<string> THardDeleteSenderMessageAsync(Guid messageId)
        {
            return await _messageDal.HardDeleteSenderMessageAsync(messageId);
        }
        public async Task TUndoMakeTheMessageImportant(Guid messageId)
        {
            await _messageDal.UndoMakeTheMessageImportant(messageId);
        }

        public Task TUpdateAsync(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
