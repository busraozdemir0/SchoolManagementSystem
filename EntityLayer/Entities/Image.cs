using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Image:BaseEntity<Guid>
    {
        // Entity Constructure
        public Image()
        {

        }
        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<AppUser> Users { get; set;}
        public ICollection<Report> Reports { get; set;}
        public ICollection<About> Abouts { get; set;}
    }
}
