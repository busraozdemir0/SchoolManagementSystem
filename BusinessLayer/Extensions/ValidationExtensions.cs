using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extensions
{
    public static class ValidationExtensions
    {
        // ValidationResult nesnesinden gelen dogrulama hatalarini model durum sozlugune ekleyerek kullanici arayuzunde gostermemizi saglar
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach(var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        // Identity kutuphanesinden gelen dogrulama hatalarini kullaniciya sunabilmek icin kullanilir
        public static void AddToIdentityModelState(this IdentityResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors) 
            {
                modelState.AddModelError("", error.Description);
            }
        }
    }
}
