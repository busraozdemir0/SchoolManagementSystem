using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x=>x.Subject)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("Konu");

            RuleFor(x => x.Content)
                .NotNull()
                .MinimumLength(2)
                .WithName("Mesaj");

            RuleFor(x => x.SenderUserEmail)
                .NotEmpty()
                .EmailAddress()
                .WithName("Gönderen E-Mail");

            RuleFor(x => x.ReceiverUserEmail)
                .NotEmpty()
                .EmailAddress()
                .WithName("Alıcı E-Mail");
        }
    }
}
