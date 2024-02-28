using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int currentPage=1, int pageSize=6, bool isAscending=false)
        {
            var reports = await _reportService.TGetAllByPagingAsync(currentPage,pageSize,isAscending);
            return View(reports);

        }
        public async Task<IActionResult> Detail(Guid reportId)
        {
            var report = await _reportService.TGetByGuidAsync(reportId);
            var map=_mapper.Map<ReportDto>(report);
            return View(map);
        }
    }
}
