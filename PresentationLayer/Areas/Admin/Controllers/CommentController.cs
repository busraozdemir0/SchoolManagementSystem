using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DocumentFormat.OpenXml.Office2019.Word.Cid;
using EntityLayer.DTOs.Comments;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class CommentController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IValidator<Comment> _validator;
        private readonly IToastNotification _toast;

        public CommentController(IAboutService aboutService, ICommentService commentService, IMapper mapper, IValidator<Comment> validator, IToastNotification toast)
        {
            _aboutService = aboutService;
            _commentService = commentService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var comments = await _commentService.GetListAsync();
            var mapComments = _mapper.Map<List<CommentListDto>>(comments);
            return View(mapComments);
        }

        public async Task<IActionResult> DeletedComments()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var comments = await _commentService.GetDeletedListAsync();
            var mapComments = _mapper.Map<List<CommentListDto>>(comments);
            return View(mapComments);
        }

        public async Task<IActionResult> SafeDelete(Guid commentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            await _commentService.TSafeDeleteCommentAsync(commentId);
            _toast.AddSuccessToastMessage("Yorum başarıyla silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Comment", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid commentId)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            await _commentService.TUndoDeleteCommentAsync(commentId);
            _toast.AddSuccessToastMessage("Yorum başarıyla geri alındı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedComments", "Comment", new { Area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid commentId) // Tablodan tamamen silme islemi icin
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var comment = await _commentService.TGetByGuidAsync(commentId);
            await _commentService.TDeleteAsync(comment);
            _toast.AddSuccessToastMessage("Yorum tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedComments", "Comment", new { Area = "Admin" });
        }
    }
}
