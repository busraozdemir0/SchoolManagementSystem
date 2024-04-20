using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        // Sifrelerin hash'lenerek tutulabilmesi icin bu yapi olusturuluyor
        public string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(u => u.SenderUserMessages)
            .WithOne(m => m.SenderUser)
            .HasForeignKey(m => m.SenderUserId)
            .OnDelete(DeleteBehavior.Restrict); // İstege bagli: Silme davranisini belirleyebiliriz.

            builder.HasMany(u => u.ReceiverUserMessages)
                .WithOne(m => m.ReceiverUser)
                .HasForeignKey(m => m.ReceiverUserId)
                .OnDelete(DeleteBehavior.Restrict); // İstege bagli: Silme davranisini belirleyebiliriz.

            var admin = new AppUser
            {
                Id = Guid.Parse("A61F597B-2C8D-4CB4-80A6-6822178322A8"),
                Name="Admin",
                Surname="Admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Gender = "Erkek",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "(111) 111 1111",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");  // Olusturulan user'a ait 123456 sifresinin hash tabanli tutulmasi icin


            var ogretmen = new AppUser
            {
                Id = Guid.Parse("97B90210-A67F-426D-BE2C-8ADCAB3100FB"),
                Name = "Öğretmen",
                Surname = "Öğretmen",
                UserName = "ogretmen",
                NormalizedUserName = "OGRETMEN",
                Gender = "Kadın",
                Email = "ogretmen@gmail.com",
                NormalizedEmail = "OGRETMEN@GMAIL.COM",
                PhoneNumber = "(222) 222 2222",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            ogretmen.PasswordHash = CreatePasswordHash(ogretmen, "123456");

            var ogrenci = new AppUser
            {
                Id = Guid.Parse("A9949A78-7413-484E-A62A-EB0FB01B7F76"),
                Name = "Öğrenci",
                Surname = "Öğrenci",
                UserName = "ogrenci",
                NormalizedUserName = "OGRENCİ",
                GradeId=1,
                StudentNo=1234,
                Gender="Kadın",
                Email = "ogrenci@gmail.com",
                NormalizedEmail = "OGRENCİ@GMAIL.COM",
                PhoneNumber = "(333) 333 3333",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            ogrenci.PasswordHash = CreatePasswordHash(ogrenci, "123456");


            builder.HasData(admin, ogretmen, ogrenci);  // User tablosu icin cekirdek data'larin olusturulmasi
        }
    }
}
