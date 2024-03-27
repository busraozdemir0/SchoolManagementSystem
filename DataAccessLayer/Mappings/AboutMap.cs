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
    public class AboutMap : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasData(new About
            {
                Id = 1,
                SchoolName="Atlas Koleji",
                Title = "Çocuğunuz İçin En İyi Seçim Biziz",
                Content = "Atlas Koleji olarak 2009 yılında başladığımız yolculuğumuzda, ortaokul ve lise öğrencilerimizin başarıya ulaşmasını hedefliyor aynı " +
                "zamanda hayalindeki lise ve üniversiteleri kazanmaları için elimizden geleni yapıyoruz. Okulda yapılan eğitimin yanı sıra web sitemiz sayesinde " +
                "konuları pekiştirebilme ve birebir öğretmenle iletişime geçme imkanına sahip olabilecekler. Bu güne kadar mezunlarımızın çoğuna Türkiye'de oldukça " +
                "ünlü okulları kazanabilmelerine vesile olduk. Hemen siz de iletişime geçin ve uygun fiyatlarla kolejimize " +
                "kaydolarak hayallerinize ulaşın."
            });
        }
    }
}
