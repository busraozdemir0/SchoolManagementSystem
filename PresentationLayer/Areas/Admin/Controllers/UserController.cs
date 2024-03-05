using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Context;
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
        public async Task<IActionResult> GetAllTeachers()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            return View(users);
        }
        public async Task<IActionResult> GetAllStudents()
        {
            var users = await _userService.TGetAllUsersWithRoleAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleService.TGetAllRolesAsync();
            return View(new UserAddDto { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var mapUser = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(mapUser);

            var roles = await _roleService.TGetAllRolesAsync(); // Tum roller

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
                    _toast.AddErrorToastMessage("Kullanıcı eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });

                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userService.TGetAppUserByIdAsync(userId);

            var userRole = await _userService.TGetUserRoleAsync(user); // Kullanicinin rolu
            var userRoleId = await _roleService.TGetByIdRoleAsync(userRole);

            var roles = await _roleService.TGetAllRolesAsync(); // Roller
            
            var mapUserUpdateDto = _mapper.Map<UserUpdateDto>(user);
            mapUserUpdateDto.Roles = roles;
            mapUserUpdateDto.RoleId = userRoleId;
            return View(mapUserUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userService.TGetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null) // Eger boyle bir kullanici varsa
            {
                var roles = await _roleService.TGetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateDto, user); // Dto ile guncellenecek olan kullanici(user) birbirine esleniyor.
                                                                // Bu kod satiri aslinda asagidaki islemi yapmaktadir
                                                                //user.Name = userUpdateDto.Name;
                                                                //user.Name = userUpdateDto.Name;
                                                                //user.Email = userUpdateDto.Email;
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userService.TUpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            _toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.UserName), new ToastrOptions { Title = "Başarılı!" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            _toast.AddErrorToastMessage("Kullanıcı güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }               
            }
            return NotFound(); // User'ı bulamazsa NotFound donecek.
        }

        public async Task<IActionResult> Delete(Guid userId)
        {
            // Identity'nin ondelete metodlarında eger bir kullanici silinirse kullaniciya bagli olan roller de silindigi icin ayriyetten rol silme islemine gerek kalmamaktadir.
            var result = await _userService.TDeleteUserAsync(userId); // Buradan hem identityResult hem de kullanici adi donecek.
            if (result.identityResult.Succeeded)
            {
                _toast.AddSuccessToastMessage(Messages.User.Delete(result.userName), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
                _toast.AddErrorToastMessage("Kullanıcı silinirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
            }
            return View();
        }
    }
}
