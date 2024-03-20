using AutoMapper;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Reports;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Teacher.ViewComponents
{
	public class DashboardLastSixReportViewComponent:ViewComponent
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public DashboardLastSixReportViewComponent(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var report = await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted, i => i.Image);

			var reportLastThree = report.OrderByDescending(x => x.CreatedDate).Take(6); // Haberleri tarihe gore azalan bicimde siralar ve ilk 6 haberi alir.

			var map = _mapper.Map<List<ReportDto>>(reportLastThree);

			return View(map);
		}
	}
}
