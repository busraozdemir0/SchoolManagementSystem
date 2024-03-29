﻿using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.LessonVideos
{
    public class LessonVideoAddDto
    {
        public string Title { get; set; }
        public string? YoutubeVideoPath { get; set; }
        public IFormFile Video { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}