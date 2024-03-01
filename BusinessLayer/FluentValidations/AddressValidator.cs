using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.AddressInfo)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(150)
                .WithName("Adres Bilgisi");

            RuleFor(x => x.EMail)
                .NotEmpty()
                .EmailAddress()
                .WithName("E-Mail");

            RuleFor(x => x.SupportEMail)
                .NotEmpty()
                .EmailAddress()
                .WithName("Destek E-Mail");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(14)
                .WithName("Telefon Numarası");

        }
    }
}
