using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer.Entities
{
    public class About: BaseEntity<int>
    {
        public About()
        {
            
        }
        public About(string schoolName, string title, string content, Guid imageId)
        {
            SchoolName = schoolName;
            Title=title;
            Content=content;
            ImageId = imageId;
        }
        public string SchoolName { get; set; } // Projedeki okul adini degistirebilmek icin
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
