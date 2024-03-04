using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUser> _validator;
        private readonly IToastNotification _toast;

        public UserController(IUserService userService, IMapper mapper, IRoleService roleService, IValidator<AppUser> validator, IToastNotification toast)
        {
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;
            _validator = validator;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleService.TGetAllRolesAsync();
            return View(new UserAddDto { Roles=roles });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(mapUser);

            var roles=await _roleService.TGetAllRolesAsync(); // Tum roller

            if (ModelState.IsValid)
            {
                var result = await _userService.TCreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    _toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);

                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }
    }
}
