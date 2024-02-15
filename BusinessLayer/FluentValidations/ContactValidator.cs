using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("İsim Soyisim");

            RuleFor(x => x.EMail)
                .NotEmpty()
                .EmailAddress()
                .WithName("E-Mail");
            
            RuleFor(x => x.Subject)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("Konu");

            RuleFor(x => x.Message)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Mesaj");

            
        }
    }
}
