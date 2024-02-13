using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole
            {
                Id = Guid.Parse("C54083A8-1FF1-43D0-9B51-C2FEA5B3E60D"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString() // ayni anda iki farkli islem yapiliyorsa bunlarin cakismasini engeller (ayni anda ayni verinin guncellenme islemi gibi)
            },
            new AppRole
            {
                Id = Guid.Parse("23420044-C9AE-462E-8317-88DB8C734DE1"),
                Name = "Teacher",
                NormalizedName = "TEACHER",
                ConcurrencyStamp = Guid.NewGuid().ToString() // ayni anda iki farkli islem yapiliyorsa bunlarin cakismasini engeller (ayni anda ayni verinin guncellenme islemi gibi)
            },
            new AppRole
            {
                Id = Guid.Parse("2157A98D-0223-4AE6-AFB9-5F586E9BA4AE"),
                Name = "Student",
                NormalizedName = "STUDENT",
                ConcurrencyStamp = Guid.NewGuid().ToString() // ayni anda iki farkli islem yapiliyorsa bunlarin cakismasini engeller (ayni anda ayni verinin guncellenme islemi gibi)
            }
            ,
            new AppRole
            {
                Id = Guid.Parse("8DB4507C-EE16-4F5F-82A6-D187A2ACB21D"),
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString() // ayni anda iki farkli islem yapiliyorsa bunlarin cakismasini engeller (ayni anda ayni verinin guncellenme islemi gibi)
            });
        }
    }
}
