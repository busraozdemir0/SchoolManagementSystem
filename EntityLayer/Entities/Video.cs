using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Video:BaseEntity<Guid>
    {
        public Video()
        {
            
        }
        public Video(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<LessonVideo> LessonVideos { get; set; }
    }
}
