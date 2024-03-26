﻿using EntityLayer.DTOs.Lessons;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.LessonScores
{
    public class LessonScoreUpdateDto
    {
        public Guid Id { get; set; }
        public int? StudentNo { get; set; }
        public string GradeName { get; set; }
        public double? Score1 { get; set; } 
        public double? Score2 { get; set; }
        public double? PerformanceScore { get; set; } 
        public string CreatedBy { get; set; } 
        public Guid LessonId { get; set; } 
        public IList<LessonListDto> Lessons { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
