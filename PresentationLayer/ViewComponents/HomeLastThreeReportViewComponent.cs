using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeLastThreeReportViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeLastThreeReportViewComponent(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var report = await _unitOfWork.GetRepository<Report>().GetAllAsync();

            var reportLastThree = report.OrderByDescending(x => x.CreatedDate).Take(3); // Haberleri tarihe gore azalan bicimde siralar ve ilk 3 haberi alir.

            var map = _mapper.Map<List<ReportDto>>(reportLastThree);

            return View(map);
        }
    }
}
