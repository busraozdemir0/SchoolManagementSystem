using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Consts;
using EntityLayer.DTOs.Roles;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class RoleController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;
        private readonly IValidator<AppRole> _validator;

        public RoleController(IRoleService roleService, IMapper mapper, IToastNotification toast, IValidator<AppRole> validator, IAboutService aboutService)
        {
            _roleService = roleService;
            _mapper = mapper;
            _toast = toast;
            _validator = validator;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

            var roles = await _roleService.TGetAllRolesAsync();
            var mapRoles = _mapper.Map<List<RoleListDto>>(roles);
            return View(mapRoles);
        }

        // ** Proje seneryosu gereği Rol ekleme, silme, guncelleme islemleri pasiflestirildi.

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(RoleAddDto roleAddDto)
        //{
        //    ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

        //    var mapRole = _mapper.Map<AppRole>(roleAddDto);
        //    var validation = await _validator.ValidateAsync(mapRole);

        //    if (validation.IsValid)
        //    {
        //        var result = await _roleService.TCreateRoleAsync(roleAddDto);

        //        if (result.Succeeded)
        //        {
        //            _toast.AddSuccessToastMessage(Messages.Role.Add(roleAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
        //            return RedirectToAction("Index", "Role", new { Area = "Admin" });
        //        }
        //        else
        //        {
        //            result.AddToIdentityModelState(this.ModelState);
        //            _toast.AddErrorToastMessage("Rol eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });

        //            validation.AddToModelState(this.ModelState);
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        validation.AddToModelState(this.ModelState);

        //        _toast.AddErrorToastMessage("Rol eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
        //        return View();
        //    }

        //}

        //[HttpGet]
        //public async Task<IActionResult> Update(Guid roleId)
        //{
        //    ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

        //    var role = await _roleService.TFindByIdRoleAsync(roleId);
        //    var mapRole = _mapper.Map<RoleUpdateDto>(role);

        //    return View(mapRole);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(RoleUpdateDto roleUpdateDto)
        //{
        //    ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

        //    var mapRole = _mapper.Map<AppRole>(roleUpdateDto);
        //    var validation = await _validator.ValidateAsync(mapRole);

        //    if (validation.IsValid)
        //    {
        //        var result = await _roleService.TUpdateRoleAsync(roleUpdateDto);

        //        if (result.Succeeded)
        //        {
        //            _toast.AddSuccessToastMessage(Messages.Role.Update(roleUpdateDto.Name), new ToastrOptions { Title = "Başarılı!" });
        //            return RedirectToAction("Index", "Role", new { Area = "Admin" });
        //        }
        //        else
        //        {
        //            result.AddToIdentityModelState(this.ModelState);

        //            _toast.AddErrorToastMessage("Rol güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        validation.AddToModelState(this.ModelState);
        //        _toast.AddErrorToastMessage("Rol eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });

        //        return View();
        //    }
        //}

        //public async Task<IActionResult> Delete(Guid roleId)
        //{
        //    ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

        //    var result = await _roleService.TDeleteRoleAsync(roleId);

        //    if (result.identityResult.Succeeded)
        //    {
        //        _toast.AddSuccessToastMessage(Messages.Role.Delete(result.roleName), new ToastrOptions { Title = "Başarılı!" });
        //        return RedirectToAction("Index", "Role", new { Area = "Admin" });
        //    }
        //    else
        //    {
        //        result.identityResult.AddToIdentityModelState(this.ModelState);
        //        _toast.AddErrorToastMessage("Rol silinirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
        //    }
        //    return View();
        //}

    //    [HttpPost]
    //    public async Task<IActionResult> AddWithAjax([FromBody] RoleAddDto roleAddDto)
    //    {
    //        ViewBag.SchoolName = await _aboutService.TGetSchoolNameAsync();

    //        var mapRole = _mapper.Map<AppRole>(roleAddDto);
    //        var validation = await _validator.ValidateAsync(mapRole);

    //        if (validation.IsValid)
    //        {
    //            var result = await _roleService.TCreateRoleAsync(roleAddDto);

    //            if (result.Succeeded)
    //            {
    //                _toast.AddSuccessToastMessage(Messages.Role.Add(roleAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
    //                return Json(Messages.Role.Add(roleAddDto.Name));
    //            }
    //            else
    //            {
    //                result.AddToIdentityModelState(this.ModelState);
    //                _toast.AddErrorToastMessage("Rol eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });

    //                return Json(result.Errors.First().Description);
    //            }
    //        }
    //        else
    //        {
    //            _toast.AddErrorToastMessage(validation.Errors.First().ErrorMessage, new ToastrOptions { Title = "Başarısız!" });
    //            return Json(validation.Errors.First().ErrorMessage);
    //        }
    //    }
    }
}
