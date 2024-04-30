using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Comments;
using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = RoleConsts.Teacher)]
    public class CommentController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ICommentService _commentService;
        private readonly IToastNotification _toast;
        private readonly IValidator<Comment> _validator;
        private readonly IMapper _mapper;

        public CommentController(IAboutService aboutService, ICommentService commentService, IToastNotification toast, IMapper mapper, IValidator<Comment> validator)
        {
            _aboutService = aboutService;
            _commentService = commentService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddDto commentAddDto)
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var mapComment = _mapper.Map<Comment>(commentAddDto);
            var result = await _validator.ValidateAsync(mapComment);

            if (result.IsValid)
            {
                await _commentService.TAddAsync(mapComment);

                _toast.AddSuccessToastMessage("Başarıyla yorum yaptınız.", new ToastrOptions { Title = "İşlem Başarılı!" });
                return RedirectToAction("Index", "Home", new { Area = "Teacher" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                _toast.AddErrorToastMessage("Yorum yapılırken bir sorun oluştu.", new ToastrOptions { Title = "İşlem Başarısız!" });
            }
            return View();
        }
    }
}
