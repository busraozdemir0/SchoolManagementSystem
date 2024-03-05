using EntityLayer.DTOs.NewsLetters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class SendNewsLetterEmailValidator:AbstractValidator<NewsLetterSendEmailDto>
    {
        public SendNewsLetterEmailValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Konu");

            RuleFor(x => x.Message)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Mesaj");
            
        }
    }
}
