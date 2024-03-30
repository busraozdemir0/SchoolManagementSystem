﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.LessonVideos
{
    public class LessonVideoListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? YoutubeVideoPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public Guid VideoId { get; set; }
        public Video Video { get; set; }
    }
}
