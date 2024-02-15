using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class NewsValidator:AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(200)
                .WithName("Başlık");

            RuleFor(x => x.Content)
                .NotNull()
                .MinimumLength(3)
                .WithName("İçerik");

        }
    }
}
