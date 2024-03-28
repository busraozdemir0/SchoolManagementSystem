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
    public class LessonMap : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasData(new Lesson
            {
                Id = Guid.NewGuid(),
                LessonCode = "B100",
                LessonName="Bilgisayar Sistemleri",
                LessonCredit = 2,
                IsDeleted = false,
                GradeId = 1,
                UserId= Guid.Parse("97B90210-A67F-426D-BE2C-8ADCAB3100FB")
            },
            new Lesson
            {
                Id = Guid.NewGuid(),
                LessonCode = "M102",
                LessonName = "Matematik",
                LessonCredit = 5,
                IsDeleted = false,
                GradeId = 2,
                UserId = Guid.Parse("97B90210-A67F-426D-BE2C-8ADCAB3100FB")
            },
            new Lesson
            {
                Id = Guid.NewGuid(),
                LessonCode = "F205",
                LessonName = "Fizik",
                LessonCredit = 3,
                IsDeleted = false,
                GradeId = 3,
                UserId = Guid.Parse("97B90210-A67F-426D-BE2C-8ADCAB3100FB")
            },
            new Lesson
            {
                Id = Guid.NewGuid(),
                LessonCode = "B101",
                LessonName = "Biyoloji",
                LessonCredit = 3,
                IsDeleted = false,
                GradeId = 4,
                UserId = Guid.Parse("97B90210-A67F-426D-BE2C-8ADCAB3100FB")
            });
        }
    }
}
