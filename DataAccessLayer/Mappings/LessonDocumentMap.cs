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
    public class LessonDocumentMap : IEntityTypeConfiguration<LessonDocument>
    {
        public void Configure(EntityTypeBuilder<LessonDocument> builder)
        {
            builder.HasData(new LessonDocument
            {
                Id = Guid.NewGuid(),
                Title = "Deneme",
                DocumentPath = "test",
                IsDeleted=false
            }
            );
        }
    }
}
