
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
        public IPagedList<LessonScore> LessonScores { get; set; }
        public IPagedList<Report> Reports { get; set; }
        public IPagedList<AppRole> Roles { get; set; }
        public IPagedList<AppUser> Users { get; set; }
        public IPagedList<Message> Messages { get; set; }
        public IPagedList<Comment> Comments { get; set; }
        public IPagedList<SocialMedia> SocialMedias { get; set; }
    }
}
