using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Contacts;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Reports;
using EntityLayer.DTOs.Roles;
using EntityLayer.DTOs.Users;

namespace EntityLayer.DTOs.Search
{
    public class SearchModel
    {    
        public List<AnnouncementListDto> Announcements { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public List<GradeListDto> Grades { get; set; }
        public List<LessonListDto> Lessons { get; set; }
        public List<ReportDto> Reports { get; set; }
        public List<RoleListDto> Roles { get; set; }
        public List<UserListDto> Users { get; set; }

    }
}
