using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NToastNotify;
using PresentationLayer.ResultMessages;
using static PresentationLayer.ResultMessages.Messages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly IValidator<ReportAddDto> _validator;
        private readonly IToastNotification _toast;

        public ReportController(IReportService reportService, IMapper mapper, IValidator<ReportAddDto> validator, IToastNotification toast, IAboutService aboutService)
        {
            _reportService = reportService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var reports = await _reportService.GetListAsync();
            var mapReports = _mapper.Map<List<ReportDto>>(reports);
            return View(mapReports);
        }
        public async Task<IActionResult> DeletedReports()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var reports = await _reportService.GetDeletedListAsync();
            var mapReports = _mapper.Map<List<ReportDto>>(reports);
            return View(mapReports);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ReportAddDto reportAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var result = await _validator.ValidateAsync(reportAddDto);

            if (result.IsValid)
            {
                await _reportService.TAddReportAndImageAsync(reportAddDto);
                _toast.AddSuccessToastMessage(Messages.Report.Add(reportAddDto.Title), new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "Report", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Haber eklenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid reportId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var report = await _reportService.TGetByGuidAsync(reportId);
            var mapReport = _mapper.Map<ReportUpdateDto>(report);
            return View(mapReport);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ReportUpdateDto reportUpdateDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapReportAddDto = _mapper.Map<ReportAddDto>(reportUpdateDto);
            var result = await _validator.ValidateAsync(mapReportAddDto);

            if (result.IsValid)
            {
                await _reportService.TUpdateReportAndImageAsync(reportUpdateDto);
                _toast.AddSuccessToastMessage(Messages.Report.Update(reportUpdateDto.Title), new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "Report", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Haber güncellenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });
            }
            var report = await _reportService.TGetByGuidAsync(reportUpdateDto.Id);
            var mapReport = _mapper.Map<ReportUpdateDto>(report);
            return View(new ReportUpdateDto { ImageId = mapReport.ImageId, Image = mapReport.Image });
        }

        public async Task<IActionResult> SafeDelete(Guid reportId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var reportTitle = await _reportService.TSafeDeleteReportAsync(reportId);

            _toast.AddSuccessToastMessage(Messages.Report.Delete(reportTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Report", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid reportId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var reportTitle = await _reportService.TUndoDeleteReportAsync(reportId);

            _toast.AddSuccessToastMessage(Messages.Report.UndoDelete(reportTitle), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedReports", "Report", new { Area = "Admin" });
        }
        public async Task<IActionResult> HardDelete(Guid reportId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var report = await _reportService.TGetByGuidAsync(reportId);
            await _reportService.TDeleteAsync(report);
            _toast.AddSuccessToastMessage("Haber tamamen kaldırıldı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedReports", "Report", new { Area = "Admin" });
        }
    }
}
