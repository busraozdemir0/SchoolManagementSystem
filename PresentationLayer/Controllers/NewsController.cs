using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.News;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        private readonly IValidator<News> _validator;

        public NewsController(INewsService newsService, IMapper mapper, IValidator<News> validator)
        {
            _newsService = newsService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetListAsync();
            var map = _mapper.Map<List<NewsDto>>(news);
            return View(map);
        }
        public async Task<IActionResult> Detail(Guid newsId)
        {
            var news=await _newsService.TGetByGuidAsync(newsId);
            var map=_mapper.Map<NewsDto>(news);
            return View(map);
        }
    }
}
