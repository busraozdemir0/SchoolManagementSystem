using AutoMapper;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace PresentationLayer.ViewComponents
{
    public class HomeCommentsViewComponent:ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public HomeCommentsViewComponent(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var comments = await _commentService.GetListAsync();
            var orderedComments = comments.OrderByDescending(x => x.CreatedDate).Take(5);  // Son yapilan 5 yorum listelenecek
            var mapComments = _mapper.Map<List<CommentHomeListDto>>(orderedComments);
            return View(mapComments);
        }
    }
}
