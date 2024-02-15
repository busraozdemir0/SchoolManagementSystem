using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class GradeValidator:AbstractValidator<Grade>
    {
        public GradeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .WithName("Sınıf Adı");
        }
    }
}
