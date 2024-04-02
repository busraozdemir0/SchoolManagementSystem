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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(new Address
            {
                Id = 1,
                AddressInfo = "Düzce Ünv., 81620 Yörük/Düzce Merkez/Düzce",
                EMail = "atlaskolej@gmail.com",
                SupportEMail = "destek@atlaskoleji.com",
                PhoneNumber = "(111) 111 1111",
                MapLocation = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12062.0903918608!2d31.180443!3d40.904286!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x409da0c35c97aa71%3A0x93cc0b0387c8fc40!2zRMO8emNlIMOcbml2ZXJzaXRlc2kgTcO8aGVuZGlzbGlrIEZha8O8bHRlc2k!5e0!3m2!1str!2str!4v1711622193416!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade",
                IsDeleted = false,
            });
        }
    }
}
