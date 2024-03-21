using DataAccessLayer.Repository.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAnnouncementDal : IRepository<Announcement>
    {
        Task<string> SafeDeleteAnnouncementAsync(Guid announcementId);
        Task<string> UndoDeleteAnnouncementAsync(Guid announcementId);

        Task<List<Announcement>> TeacherAnnouncementListAsync(); // Teacher kullanicilarina yapilan duyurulari listelemek icin

        Task<List<Announcement>> AnnouncementToStudentsListAsync(); // Giren ogretmen kullanicisinin ogrencilere yaptigi duyurular
    }
}
