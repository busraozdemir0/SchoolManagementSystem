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
    public class SocialMediaMap : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasData(new SocialMedia
            {
                Id = 1,
                Title = "LinkedIn",
                Url = "https://www.linkedin.com/in/busra0zdemir/",
                IconInfo = "fab fa-linkedin",
            },
            new SocialMedia
            {
                Id = 2,
                Title = "GitHub",
                Url = "https://github.com/busraozdemir0",
                IconInfo = "fab fa-github",
            },
            new SocialMedia
            {
                Id = 3,
                Title = "X",
                Url = "https://twitter.com/busraozdemiir",
                IconInfo = "fa-brands fa-x-twitter",
            },
            new SocialMedia
            {
                Id = 4,
                Title = "Instagram",
                Url = "https://www.instagram.com/busra.0zdemir/",
                IconInfo = "fab fa-instagram",
            });
        }
    }
}
