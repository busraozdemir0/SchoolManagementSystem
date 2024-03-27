using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.SchoolName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Okul Adı");

            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Başlık");

            RuleFor(x => x.Content)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("İçerik");
        }
    }
}
