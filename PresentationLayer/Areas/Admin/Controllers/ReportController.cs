using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly IValidator<ReportAddDto> _validator;
        private readonly IToastNotification _toast;

        public ReportController(IReportService reportService, IMapper mapper, IValidator<ReportAddDto> validator, IToastNotification toast)
        {
            _reportService = reportService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var reports = await _reportService.GetListAsync();
            var mapReports = _mapper.Map<List<ReportDto>>(reports);
            return View(mapReports);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ReportAddDto reportAddDto)
        {
            var result = await _validator.ValidateAsync(reportAddDto);

            if (result.IsValid)
            {
                await _reportService.TAddReportAndImageAsync(reportAddDto);
                _toast.AddSuccessToastMessage("Haber başarıyla eklendi", new ToastrOptions { Title = "Başarılı!" });

                return RedirectToAction("Index", "Report", new {Area="Admin"});
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Haber eklenirken bir sorun oluştu", new ToastrOptions { Title = "Başarısız!" });

            }
            return View();
        }
    }
}
