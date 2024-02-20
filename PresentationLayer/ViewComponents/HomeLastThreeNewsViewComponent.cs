using AutoMapper;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.News;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HomeLastThreeNewsViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeLastThreeNewsViewComponent(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var news = await _unitOfWork.GetRepository<News>().GetAllAsync();

            var newsLastThree = news.OrderByDescending(x => x.CreatedDate).Take(3); // Haberleri tarihe gore azalan bicimde siralar ve ilk 3 haberi alir.

            var map = _mapper.Map<List<NewsDto>>(newsLastThree);

            return View(map);
        }
    }
}
