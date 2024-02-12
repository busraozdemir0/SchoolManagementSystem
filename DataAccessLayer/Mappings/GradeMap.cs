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
    public class GradeMap : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasData(new Grade
            {
                Id = 1,
                Name = "9. Sınıf"
            },
            new Grade
            {
                Id = 2,
                Name = "10. Sınıf"
            },
            new Grade
            {
                Id = 3,
                Name = "11. Sınıf"
            },
            new Grade
            {
                Id = 4,
                Name = "12. Sınıf"
            });
        }
    }
}
