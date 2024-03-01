using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Abouts
{
    public class AboutUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
