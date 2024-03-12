using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Contacts;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Reports;
using EntityLayer.DTOs.Roles;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using X.PagedList;

namespace EntityLayer.DTOs.Search
{
    public class SearchModel
    {    
        public IPagedList<Announcement> Announcements { get; set; }
        public IPagedList<Contact> Contacts { get; set; }
        public IPagedList<Grade> Grades { get; set; }
        public IPagedList<Lesson> Lessons { get; set; }
        public IPagedList<Report> Reports { get; set; }
        public IPagedList<AppRole> Roles { get; set; }
        public IPagedList<AppUser> Users { get; set; }

    }
}
