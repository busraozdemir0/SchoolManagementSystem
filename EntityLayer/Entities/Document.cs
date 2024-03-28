using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Document : BaseEntity<Guid>
    {
        public Document()
        {
            
        }
        public Document(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<LessonDocument> LessonDocuments { get; set; }
    }
}
