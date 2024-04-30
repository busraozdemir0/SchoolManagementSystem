using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x=>x.Content)
                .NotEmpty()
                .MinimumLength(20)
                .MaximumLength(300)
                .WithName("İçerik");
        }
    }
}
