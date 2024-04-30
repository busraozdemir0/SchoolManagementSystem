using BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeStatisticsViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IGradeService _gradeService;
        private readonly IReportService _reportService;

        public HomeStatisticsViewComponent(IUserService userService, IGradeService gradeService, IReportService reportService)
        {
            _userService = userService;
            _gradeService = gradeService;
            _reportService = reportService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var students = await _userService.TGetAllStudentsWithRoleAsync();
            ViewBag.studentCount = students.Count;

            var teachers = await _userService.TGetAllTeachersWithRoleAsync();
            ViewBag.teacherCount = teachers.Count;

            var grades = await _gradeService.GetListAsync();
            ViewBag.gradeCount = grades.Count;

            var reports = await _reportService.GetListAsync();
            ViewBag.reportCount = reports.Count;

            return View();
        }
    }
}
