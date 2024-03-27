using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.LessonScores;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class StudentController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IUserService _userService;

        public StudentController(IUserService userService, IAboutService aboutService)
        {
            _userService = userService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var users = await _userService.TGetAllUsersWithRoleAsync();
            var studentInClasses = await _userService.TStudentInClassListAsync(users); // Giren ogretmenin ders verdigi siniflarda bulunan ogrenciler listesi
            return View(studentInClasses);
        }

        public async Task<IActionResult> StudentExcelReport() // Ogrenciler listesini excel formatinda indirmek icin
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var users = await _userService.TGetAllUsersWithRoleAsync();
            var studentInClasses = await _userService.TStudentInClassListAsync(users); // Giren ogretmenin ders verdigi siniflarda bulunan ogrenciler listesi

            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Öğrenci Listesi");
                workSheet.Cell(1, 1).Value = "Öğrenci Numarası";
                workSheet.Cell(1, 2).Value = "Adı";
                workSheet.Cell(1, 3).Value = "Soyadı";
                workSheet.Cell(1, 4).Value = "Cinsiyeti";
                workSheet.Cell(1, 5).Value = "Sınıfı";
                workSheet.Cell(1, 6).Value = "Telefon Numarası";
                workSheet.Cell(1, 7).Value = "E-Mail";

                int rowCount = 2;
                foreach (var item in studentInClasses)
                {
                    workSheet.Cell(rowCount, 1).Value = item.StudentNo;
                    workSheet.Cell(rowCount, 2).Value = item.Name;
                    workSheet.Cell(rowCount, 3).Value = item.Surname;
                    workSheet.Cell(rowCount, 4).Value = item.Gender;
                    workSheet.Cell(rowCount, 5).Value = item.Grade.Name;
                    workSheet.Cell(rowCount, 6).Value = item.PhoneNumber;
                    workSheet.Cell(rowCount, 7).Value = item.Email;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StudentsList.xlsx");
                }
            }
        }
        
    }
}
