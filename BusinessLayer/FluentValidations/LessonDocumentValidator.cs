using EntityLayer.DTOs.LessonDocuments;
using EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class LessonDocumentValidator:AbstractValidator<LessonDocumentAddDto>
    {
        public LessonDocumentValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(60)
                .WithName("Materyal Başlığı");
        }
    }
}
