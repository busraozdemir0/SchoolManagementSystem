using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class ReportAddDtoValidator:AbstractValidator<ReportAddDto>
    {
        public ReportAddDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(200)
                .WithName("Başlık");

            RuleFor(x => x.Content)
                .NotNull()
                .MinimumLength(3)
                .WithName("İçerik");

        }
    }
}
