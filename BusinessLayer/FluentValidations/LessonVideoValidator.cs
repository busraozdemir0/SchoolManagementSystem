using EntityLayer.DTOs.LessonVideos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class LessonVideoValidator:AbstractValidator<LessonVideoAddDto>
    {
        public LessonVideoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(60)
                .WithName("Video Başlığı");

            RuleFor(x => x.YoutubeVideoPath)
                .MinimumLength(3)
                .WithName("Youtube Video Yolu");
        }
    }
}
