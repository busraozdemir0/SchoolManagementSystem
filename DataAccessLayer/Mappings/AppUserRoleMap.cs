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
    public class AppUserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(
                new AppUserRole  // Admin
                {  
                    UserId = Guid.Parse("A61F597B-2C8D-4CB4-80A6-6822178322A8"),
                    RoleId = Guid.Parse("C54083A8-1FF1-43D0-9B51-C2FEA5B3E60D")
                },
                new AppUserRole  // Teacher
                {
                    UserId = Guid.Parse("97B90210-A67F-426D-BE2C-8ADCAB3100FB"),
                    RoleId = Guid.Parse("23420044-C9AE-462E-8317-88DB8C734DE1")
                },
                new AppUserRole  // Student
                {
                    UserId = Guid.Parse("A9949A78-7413-484E-A62A-EB0FB01B7F76"),
                    RoleId = Guid.Parse("2157A98D-0223-4AE6-AFB9-5F586E9BA4AE")
                }
            );
        }
    }
}
