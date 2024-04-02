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
		Task<List<Announcement>> TeacherAnnouncementListAsync(); // Öğretmen panelinde - Teacher kullanicilarina yapilan duyurulari listelemek icin

        Task<List<Announcement>> TeacherAnnouncementToStudentsListAsync(); // Giren ogretmen kullanicisinin ogrencilere yaptigi duyurular
        Task<List<Announcement>> TeacherAnnouncementToStudentsDeletedListAsync(); // Giren ogretmen kullanicisinin ogrencilere yaptigi kaldirilmis duyurular 

	}
}
