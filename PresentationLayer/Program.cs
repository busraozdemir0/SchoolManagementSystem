using BusinessLayer.Describers;
using BusinessLayer.Extensions;
using BusinessLayer.FluentValidations;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// DataAccess katmani icin yazilan Extensions'lar
builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadBusinessLayerExtension();

// Add services to the container.
builder.Services.AddControllersWithViews()
     .AddNToastNotifyNoty(new NotyOptions()  // Toastr bildirimleri icin configurasyon
     {
         Layout = "bottomRight",  // Bildirimin sag alt kosede cikmasi icin
         Timeout = 3000   // Bildirim kac ms gosterilsin (3 sn olarak belirttik)
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
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
