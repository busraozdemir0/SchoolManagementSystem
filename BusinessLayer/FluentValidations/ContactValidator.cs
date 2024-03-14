using EntityLayer.DTOs.Contacts;
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
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("İsim Soyisim");

            RuleFor(x => x.EMail)
                .NotNull()
                .EmailAddress()
                .WithName("E-Mail");
            
            RuleFor(x => x.Subject)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("Konu");

            RuleFor(x => x.Message)
                .NotNull()
                .MinimumLength(2)
                .WithName("Mesaj");

            
        }
    }
}
