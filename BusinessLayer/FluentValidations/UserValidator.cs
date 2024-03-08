using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class UserValidator:AbstractValidator<AppUser>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İsim");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100)
                .WithName("Soyisim");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(14)
                .WithName("Telefon Numarası");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithName("Kullanıcı Adı");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithName("E-Mail");

        }

    }
}
