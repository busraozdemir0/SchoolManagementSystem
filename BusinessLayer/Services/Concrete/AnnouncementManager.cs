using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public AnnouncementManager(IAnnouncementDal announcementDal, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _announcementDal = announcementDal;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
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
            var userId = _user.GetLoggedInUserId(); // Login olan kullanicinin id'sini getirir.
            var userName = _user.GetLoggedInUserName(); // Login olan kullanicinin username'ini getirir.

            var announcement = new Announcement
            {
                Title = t.Title,
                Content=t.Content,
                CreatedDate=t.CreatedDate,
                RoleId=t.RoleId,
                UserId= userId, // Giren kisinin id'si
                CreatedBy=userName
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
            t.UserId = _user.GetLoggedInUserId(); ;  // Giren kisinin id'si
            t.CreatedBy = _user.GetLoggedInUserName(); // Giren kisinin userName'i

            await _announcementDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
