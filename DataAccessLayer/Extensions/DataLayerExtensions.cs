using DataAccessLayer.Context;
using DataAccessLayer.Helpers.Documents;
using DataAccessLayer.Helpers.Images;
using DataAccessLayer.Helpers.Search;
using DataAccessLayer.Helpers.Videos;
using DataAccessLayer.Repository.Abstract;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection"))); // Baglanti stringinin servis olarak belirtilmesi

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>(); // IUnitOfWork istendiginde UnitOfWork'u kullanacak.

            services.AddScoped<IImageHelper, ImageHelper>(); // Gorselleri Image tablosunda tutacagimiz icin Helper yazdik.
            services.AddScoped<IDocumentHelper, DocumentHelper>(); // Ders dokumanlarini LessonDocument tablosunda tutacak helper
            services.AddScoped<IVideoHelper, VideoHelper>(); // Ders videolarini LessonVideo tablosunda tutacak helper
            
            services.AddScoped<ISearchProcess, SearchProcess>(); 

            return services;
        }
    }
}
