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
    public class LessonVideoVisitorMap : IEntityTypeConfiguration<LessonVideoVisitor>
    {
        public void Configure(EntityTypeBuilder<LessonVideoVisitor> builder)
        {
            builder.HasKey(x => new { x.LessonVideoId, x.VisitorId }); // LessonVideoVisitor tablosunda iki tane PK degeri tasimasi gerektigi icin bu alani kendimiz bu satir ile belirttik.
                                                                       // Aksi takdirde hata aliriz. (Coka cok iliski kurmak istedigimiz icin bu sekil de yapmaliyiz.)
        }
    }
}
