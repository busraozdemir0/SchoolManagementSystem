using BusinessLayer.Describers;
using BusinessLayer.Extensions;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using EntityLayer.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 536870912; // Ýcerisine yuklenecek dosya max 512 mb olmasi gerektigini belirtiyoruz.
});

// DataAccess katmani icin yazilan Extensions'lar
builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadBusinessLayerExtension();

// Add services to the container.
builder.Services.AddControllersWithViews()
     .AddNToastNotifyToastr(new ToastrOptions() // Toastr bildirimleri icin configurasyon
     {
         PositionClass = ToastPositions.TopRight,  // bildirimin sag ustte cikmasini sagladik
         TimeOut = 3000   // bildirim kac ms gosterilsin (3 sn olarak belirttik)
     })
     .AddRazorRuntimeCompilation(); // .AddRazorRuntimeCompilation() ile proje calisirken yapilan degisikliklerin sayfa yenilendigi gibi yansimasi icin;

// * Identity yapilandirmasi
builder.Services.AddIdentity<AppUser, AppRole>(option =>
{
    // Sifre olusturulurken buyuk kucuk harf zorunlulugu vb gibi zorunluluklarý kaldirarak burada yonetebiliriz.
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;

})
.AddRoleManager<RoleManager<AppRole>>()
.AddErrorDescriber<CustomIdentityErrorDescriber>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseNToastNotify();  // Ornegin haber eklendiginde bicimli bir sekilde bildirim mesaji verebilmek icin NToastNotify adli kutuphaneyi kullaniyoruz.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Dashboard}/{id?}"  // id? => null olabilir anlamina gelir
        );

    endpoints.MapAreaControllerRoute(
        name: "Teacher",
        areaName: "Teacher",
        pattern: "Teacher/{controller=Home}/{action=Dashboard}/{id?}" 
        );

    endpoints.MapDefaultControllerRoute();
});

app.Run();
