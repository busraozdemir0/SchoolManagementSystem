using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAnnouncementRepository : Repository<Announcement>, IAnnouncementDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfAnnouncementRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> SafeDeleteAnnouncementAsync(Guid announcementId)
        {
            var announcement = await _unitOfWork.GetRepository<Announcement>().GetAsync(x => x.Id == announcementId);

            announcement.IsDeleted = true;
            announcement.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Announcement>().UpdateAsync(announcement);
            await _unitOfWork.SaveAsync();

            return announcement.Title;
        }

        public async Task<string> UndoDeleteAnnouncementAsync(Guid announcementId)
        {
            var announcement = await _unitOfWork.GetRepository<Announcement>().GetAsync(x => x.Id == announcementId);

            announcement.IsDeleted = false;
            announcement.DeletedDate = null;

            await _unitOfWork.GetRepository<Announcement>().UpdateAsync(announcement);
            await _unitOfWork.SaveAsync();

            return announcement.Title;
        }
    }
}
