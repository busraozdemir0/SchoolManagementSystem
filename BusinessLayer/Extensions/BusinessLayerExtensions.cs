using BusinessLayer.FluentValidations;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
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

            services.AddAutoMapper(assembly);

            //services.AddScoped<IValidator<Contact>, ContactValidator>();

            //services.AddValidatorsFromAssemblyContaining<ContactValidator>();

            // Fluent validation hata mesajlarinin turkcelestirilmesi
            services.AddControllersWithViews().AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblyContaining<ContactValidator>();
                option.DisableDataAnnotationsValidation = true;
                option.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            //services.AddControllersWithViews().AddFluentValidation(option =>
            //{
            //    option.RegisterValidatorsFromAssemblyContaining<LessonValidator>();
            //    option.DisableDataAnnotationsValidation = true;
            //    option.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            //});

            return services;
        }
    }
}
