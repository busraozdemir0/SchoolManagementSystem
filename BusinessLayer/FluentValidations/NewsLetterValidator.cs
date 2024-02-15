using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class NewsLetterValidator:AbstractValidator<NewsLetter>
    {
        public NewsLetterValidator()
        {
            RuleFor(x => x.EMail)
                .EmailAddress()
                .WithName("E-Mail");
        }
    }
}
