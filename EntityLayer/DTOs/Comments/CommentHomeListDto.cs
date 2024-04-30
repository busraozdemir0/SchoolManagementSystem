using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Comments
{
    public class CommentHomeListDto
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public AppUser User { get; set; }

    }
}
