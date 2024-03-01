using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.NewsLetters
{
    public class NewsLetterListDto
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public bool IsDeleted { get; set; }
    }
}
