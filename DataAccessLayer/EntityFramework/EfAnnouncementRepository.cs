using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using DataAccessLayer.Extensions;

namespace DataAccessLayer.EntityFramework
{
    public class EfAnnouncementRepository : Repository<Announcement>, IAnnouncementDal
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleDal _roleDal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public EfAnnouncementRepository(AppDbContext context, IUnitOfWork unitOfWork, IRoleDal roleDal, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _unitOfWork = unitOfWork;
            _roleDal = roleDal;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
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
        public async Task<string> SafeDeleteTeacherAnnouncementAsync(Guid announcementId)
        {
            var announcement = await _unitOfWork.GetRepository<Announcement>().GetAsync(x => x.Id == announcementId);

            announcement.TeacherStatusView = false;

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
            var teacherRoleId = await _roleDal.GetByIdRoleAsync(RoleConsts.Teacher); // Teacher rolunun id'sini bul
            var userRoleId = await _roleDal.GetByIdRoleAsync(RoleConsts.User); // Tum kullanicilara duyuru yapilmissa user kullanicisinin rolunu bul.

            var announcements = await _unitOfWork.GetRepository<Announcement>().GetAllAsync(
                    x=>x.RoleId == teacherRoleId || x.RoleId == userRoleId && !x.IsDeleted, r=>r.Role, u=>u.User);

            List<Announcement> announcementList = new();

            foreach(var announcement in announcements) 
            { 
                if(announcement.TeacherStatusView==true) // Eger Ogretmen kullanicisi o duyuruyu panelinden kaldirmamissa listeye ekle
                {
                    announcementList.Add(announcement);
                }
            }

            return announcementList;
        }

        public async Task<List<Announcement>> AnnouncementToStudentsListAsync()
        {
            var userId = _user.GetLoggedInUserId(); // Giren kisinin id'si

            var announcements = await _unitOfWork.GetRepository<Announcement>().GetAllAsync(
                x=>x.UserId==userId && !x.IsDeleted,r=>r.Role, u => u.User);

            return announcements;
        }

        
    }
}
