using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Grades;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGradeRepository : Repository<Grade>, IGradeDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfGradeRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Grade> GetGradeByIdAsync(int? id)
        {
            return await _unitOfWork.GetRepository<Grade>().GetAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<string> IsThereTheSameGradeName(string gradeName)
        {
            var grades = await _unitOfWork.GetRepository<Grade>().GetAllAsync(x => !x.IsDeleted); // Silinmemis olan siniflari getir.

            foreach (var grade in grades)
            {
                if (grade.Name == gradeName)
                {
                    return "Eklemeye çalıştığınız sınıf zaten mevcut.";
                }
            }

            return null;
        }

        public async Task<string> SafeDeleteGradeAsync(int gradeId)
        {
            var grade = await _unitOfWork.GetRepository<Grade>().GetAsync(x => x.Id == gradeId);

            grade.IsDeleted = true;
            grade.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Grade>().UpdateAsync(grade);
            await _unitOfWork.SaveAsync();

            return grade.Name;

        }

        public async Task<string> UndoDeleteGradeAsync(int gradeId)
        {
            var grade = await _unitOfWork.GetRepository<Grade>().GetAsync(x => x.Id == gradeId);

            grade.IsDeleted = false;
            grade.DeletedDate = null;

            await _unitOfWork.GetRepository<Grade>().UpdateAsync(grade);
            await _unitOfWork.SaveAsync();

            return grade.Name;
        }

    }
}
