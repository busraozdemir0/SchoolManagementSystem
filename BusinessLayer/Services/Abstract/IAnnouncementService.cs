using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IAnnouncementService:IGenericService<Announcement>
    {
        Task<string> TSafeDeleteAnnouncementAsync(Guid announcementId);
        Task<string> TUndoDeleteAnnouncementAsync(Guid announcementId);
        Task<List<Announcement>> TTeacherAnnouncementListAsync();
        Task<List<Announcement>> TAnnouncementToStudentsListAsync();
    }
}
