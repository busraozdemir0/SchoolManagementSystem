using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using EntityLayer.DTOs.Grades;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.ResultMessages;
using static PresentationLayer.ResultMessages.Messages;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        private readonly IValidator<Grade> _validator;
        private readonly IToastNotification _toast;

        public GradeController(IGradeService gradeService, IMapper mapper, IValidator<Grade> validator, IToastNotification toast)
        {
            _gradeService = gradeService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var grades=await _gradeService.GetListAsync();
            var mapGrades=_mapper.Map<List<GradeListDto>>(grades);
            return View(mapGrades);
        }
        public async Task<IActionResult> DeletedGrades()
        {
            var grades = await _gradeService.GetDeletedListAsync();
            var mapGrades = _mapper.Map<List<GradeListDto>>(grades);
            return View(mapGrades);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(GradeAddDto gradeAddDto)
        {
            var mapGrade = _mapper.Map<Grade>(gradeAddDto);
            var result=await _validator.ValidateAsync(mapGrade);

            if (result.IsValid)
            {
                await _gradeService.TAddAsync(mapGrade);
                _toast.AddSuccessToastMessage(gradeAddDto.Name + " adlı sınıf başarıyla eklendi.", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Grade", new { Area = "Admin" });
            }
            else
            {
                _toast.AddSuccessToastMessage(gradeAddDto.Name + " adlı sınıf eklenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int gradeId)
        {
            var grade = await _gradeService.TGetGradeByIdAsync(gradeId);
            var mapGrade=_mapper.Map<GradeUpdateDto>(grade);
            return View(mapGrade);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GradeUpdateDto gradeUpdateDto)
        {
            var mapGrade = _mapper.Map<Grade>(gradeUpdateDto);
            var result = await _validator.ValidateAsync(mapGrade);

            if (result.IsValid)
            {
                await _gradeService.TUpdateAsync(mapGrade);
                _toast.AddSuccessToastMessage(gradeUpdateDto.Name + " adlı sınıf başarıyla güncellendi.", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Grade", new { Area = "Admin" });
            }
            else
            {
                _toast.AddSuccessToastMessage(gradeUpdateDto.Name + " adlı sınıf güncellenirken bir sorun oluştu.", new ToastrOptions { Title = "Başarısız!" });
                result.AddToModelState(this.ModelState);
            }
            return View();
        }
        public async Task<IActionResult> SafeDelete(int gradeId)
        {
            var gradeName=await _gradeService.TSafeDeleteGradeAsync(gradeId);
            _toast.AddSuccessToastMessage(gradeName+" adlı sınıf başarıyla silindi.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Grade", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(int gradeId)
        {
            var gradeName = await _gradeService.TUndoDeleteGradeAsync(gradeId);
            _toast.AddSuccessToastMessage(gradeName + " adlı sınıf başarıyla geri alındı.", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("DeletedGrades", "Grade", new { Area = "Admin" });
        }
		public async Task<IActionResult> HardDelete(int gradeId)
		{
            var grade=await _gradeService.TGetGradeByIdAsync(gradeId);
			await _gradeService.TDeleteAsync(grade);
			_toast.AddSuccessToastMessage("Sınıf tamamen silindi.", new ToastrOptions { Title = "Başarılı!" });
			return RedirectToAction("DeletedGrades", "Grade", new { Area = "Admin" });
		}
	}
}
