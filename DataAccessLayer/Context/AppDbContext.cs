using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class AppDbContext:IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        protected AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonDocument> LessonDocuments { get; set; }
        public DbSet<LessonScore> LessonScores { get; set; }
        public DbSet<LessonVideo> LessonVideos { get; set; }
        public DbSet<Report> Reports { get; set; } // Haberler tablosu (News)
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Visitor> Visitors { get; set; } // Kullanicinin id'sini ve ip adresi gibi bilgileri tutacak (ayni user id bilgisi varsa tekrar eklenmeyecek)
        public DbSet<LessonVideoVisitor> LessonVideoVisitors { get; set; } // Videoya tiklayan ogrenci id'sini ve o videonun id'sini tutacak tablo
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
