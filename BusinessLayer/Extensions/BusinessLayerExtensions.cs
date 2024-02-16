using BusinessLayer.FluentValidations;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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

            services.AddAutoMapper(assembly);

            // Fluent validation hata mesajlarinin turkcelestirilmesi
            services.AddControllersWithViews().AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblyContaining<LessonValidator>();
                option.DisableDataAnnotationsValidation = true;
                option.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            return services;
        }
    }
}
