using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class LessonScoreValidator:AbstractValidator<LessonScore>
    {
        public LessonScoreValidator()
        {
            RuleFor(x => x.Score1)
                .GreaterThanOrEqualTo(0)  // Notlarin 0-100 arasinda olmasi gerektigi konusunda validasyon
                .LessThanOrEqualTo(100) 
                .WithName("1. Sınav");

            RuleFor(x => x.Score2)
                .GreaterThanOrEqualTo(0)  
                .LessThanOrEqualTo(100)
                .WithName("2. Sınav");

            RuleFor(x => x.PerformanceScore)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100)
                .WithName("Performans Notu");

            RuleFor(x => x.LessonId)
                .NotEmpty()
                .WithName("Ders");

        }
    }
}
