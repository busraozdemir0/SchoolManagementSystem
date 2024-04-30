using BusinessLayer.FluentValidations;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Extensions
{
    public static class BusinessLayerExtensions
    {
        public static IServiceCollection LoadBusinessLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Login olan kullaniciyi bulmamizi saglayacak olan kisim.

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactRepository>();

            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IAddressDal, EfAddressRepository>();

            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IReportDal, EfReportRepository>();

            services.AddScoped<INewsLetterService, NewsLetterManager>();
            services.AddScoped<INewsLetterDal, EfNewsLetterRepository>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutRepository>();

            services.AddScoped<IGradeService, GradeManager>();
            services.AddScoped<IGradeDal, EfGradeRepository>();

            services.AddScoped<ILessonService, LessonManager>();
            services.AddScoped<ILessonDal, EfLessonRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserRepository>();

            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IRoleDal, EfRoleRepository>(); 

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementRepository>();

            services.AddScoped<ILessonScoreService, LessonScoreManager>();
            services.AddScoped<ILessonScoreDal, EfLessonScoreRepository>();

            services.AddScoped<ILessonDocumentService, LessonDocumentManager>();
            services.AddScoped<ILessonDocumentDal, EfLessonDocumentRepository>();

            services.AddScoped<ILessonVideoService, LessonVideoManager>();
            services.AddScoped<ILessonVideoDal, EfLessonVideoRepository>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EfMessageRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddAutoMapper(assembly);

            // Fluent validation hata mesajlarinin turkcelestirilmesi
            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ContactValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            return services;
        }
    }
}
