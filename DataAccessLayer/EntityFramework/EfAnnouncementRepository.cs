using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Reports;
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
        private readonly IRoleDal _roleDal;

        public const string Teacher = "Öğretmen";
        public const string Student = "Öğrenci";
        public const string User = "Kullanıcı";
        public EfAnnouncementRepository(AppDbContext context, IUnitOfWork unitOfWork, IRoleDal roleDal) : base(context)
        {
            _unitOfWork = unitOfWork;
            _roleDal = roleDal;
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

        public async Task<List<Announcement>> TeacherAnnouncementListAsync()
        {
            var teacherRoleId = await _roleDal.GetByIdRoleAsync(Teacher); // Teacher rolunun id'sini bul
            var userRoleId = await _roleDal.GetByIdRoleAsync(User); // Tum kullanicilara duyuru yapilmissa user kullanicisinin rolunu bul.

            var announcements = await _unitOfWork.GetRepository<Announcement>().GetAllAsync(
                    x=>x.RoleId == teacherRoleId || x.RoleId == userRoleId && !x.IsDeleted, r=>r.Role, u=>u.User);

            return announcements;
        }
    }
}
