using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x=>x.Title)
                .NotEmpty()
                .MaximumLength(50)
                .WithName("Başlık");

            RuleFor(x => x.Url)
               .NotEmpty()
               .WithName("Url");

            RuleFor(x => x.IconInfo)
               .NotEmpty()
               .WithName("Sosyal Medya İkonu");
        }
    }
}
