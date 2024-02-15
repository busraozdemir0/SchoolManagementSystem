﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? UserAbout { get; set; }
        public string? Gender { get; set; }
        public string? ImagePath { get; set; }
        public int? StudentNo { get; set; } // Kayitli olacak kullanici ogrenci ise StudentNo girebilecek
        public int? GradeID { get; set; } // Kayitli olacak kullanici ogrenci ise Sinif bilgisini girebilecek
        public Grade Grade { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<LessonScore> LessonScores { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
    }
}