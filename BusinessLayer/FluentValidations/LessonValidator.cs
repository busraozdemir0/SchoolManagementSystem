using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class LessonValidator:AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(x => x.LessonName)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Ders Adı");

            RuleFor(x => x.LessonCode)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Ders Kodu");

            RuleFor(x => x.LessonCredit)
                .NotEmpty()
                .WithName("Ders Saati");
        }
    }
}
