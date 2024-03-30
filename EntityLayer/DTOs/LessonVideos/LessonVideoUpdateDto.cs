using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.LessonVideos
{
    public class LessonVideoUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? YoutubeVideoPath { get; set; }
        public string CreatedBy { get; set; }
        public Guid? VideoId { get; set; } 
        public Video Video { get; set; }
        public IFormFile? File { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
