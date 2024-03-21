using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Announcements
{
    public class AnnouncementAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid RoleId { get; set; }
        public RoleListDto? Role { get; set; }
        public ICollection<RoleListDto> Roles { get; set; }   
    }
}
