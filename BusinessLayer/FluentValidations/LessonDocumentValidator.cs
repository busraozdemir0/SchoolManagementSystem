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

            RuleFor(x => x.Material)
                .Must(file => file == null || file.Length <= 128 * 1024 * 1024) // Material bos degilse dosya boyutu kontrolu yap.
                .WithMessage("Dosya boyutu 128 MB'den büyük olamaz!");

        }
    }
}
