using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace PresentationLayer.Areas.Admin.ViewComponents
{
    public class DashboardStatistics1ViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardStatistics1ViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalUserCount = await _unitOfWork.GetRepository<AppUser>().CountAsync();
            ViewBag.TotalUserCount = totalUserCount;

            // Düzce'nin hava derecesinin cekildigi api sitesi => https://openweathermap.org/api

            string api = "110ef386282fb3d9465359d7c213c629";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=d%C3%BCzce&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.DuzceWeatherForecast = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            var totalLessonCount = await _unitOfWork.GetRepository<Lesson>().CountAsync();     
            ViewBag.TotalLessonCount = totalLessonCount;

            return View();
        }
    }
}
