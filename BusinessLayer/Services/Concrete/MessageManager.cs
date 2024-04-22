using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        private readonly IUnitOfWork _unitOfWork;

        public MessageManager(IMessageDal messageDal, IUnitOfWork unitOfWork)
        {
            _messageDal = messageDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Message>> GetDeletedListAsync()
        {
            return await _messageDal.GetAllAsync(x => x.IsDeleted == true); // Cop kutusunda listelemek icin silinmis olan mesajlari(IsDeleted bilgisi true olanlari) listeliyoruz.
        }

        public async Task<List<Message>> GetListAsync()
        {
            return await _messageDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task TAddAsync(Message t)
        {
            await _messageDal.AddAsync(t);
        }

        public async Task TDeleteAsync(Message t)
        {
            await _messageDal.DeleteAsync(t);
        }

        public async Task<Message> TGetByGuidAsync(Guid id)
        {
            return await _messageDal.GetByGuidAsync(id);
        }

        public Task TUpdateAsync(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
