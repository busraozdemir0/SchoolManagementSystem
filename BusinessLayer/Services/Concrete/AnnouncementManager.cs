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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementManager(IAnnouncementDal announcementDal, IUnitOfWork unitOfWork)
        {
            _announcementDal = announcementDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Announcement>> GetDeletedListAsync()
        {
            return await _announcementDal.GetAllAsync(x => x.IsDeleted, y => y.Role);

        }

        public async Task<List<Announcement>> GetListAsync()
        {
            return await _announcementDal.GetAllAsync(x => !x.IsDeleted,y=>y.Role);
        }

        public async Task TAddAsync(Announcement t)
        {
            var announcement = new Announcement
            {
                Title = t.Title,
                Content=t.Content,
                CreatedDate=t.CreatedDate,
                RoleId=t.RoleId,
                UserId= Guid.Parse("a61f597b-2c8d-4cb4-80a6-6822178322a8") // Giren kisinin id'si alinacak
            };
            await _announcementDal.AddAsync(announcement);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Announcement t)
        {
            await _announcementDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Announcement> TGetByGuidAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Announcement>().GetAsync(x => x.Id == id);
        }

        public async Task<string> TSafeDeleteAnnouncementAsync(Guid announcementId)
        {
            return await _announcementDal.SafeDeleteAnnouncementAsync(announcementId);
        }

        public async Task<string> TUndoDeleteAnnouncementAsync(Guid announcementId)
        {
            return await _announcementDal.UndoDeleteAnnouncementAsync(announcementId);
        }

        public async Task TUpdateAsync(Announcement t)
        {
            t.UserId = Guid.Parse("a61f597b-2c8d-4cb4-80a6-6822178322a8");  // Giren kisinin id'si alinacak
            await _announcementDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
