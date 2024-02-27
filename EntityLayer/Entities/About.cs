using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class About: BaseEntity<int>
    {
        public About()
        {
            
        }
        public About(string title, string content, Guid imageId)
        {
            Title=title;
            Content=content;
            ImageId = imageId;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
