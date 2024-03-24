using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class GradeManager : IGradeService
    {
        private readonly IGradeDal _gradeDal;
        private readonly IUnitOfWork _unitOfWork;

        public GradeManager(IGradeDal gradeDal, IUnitOfWork unitOfWork)
        {
            _gradeDal = gradeDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Grade>> GetDeletedListAsync()
        {
            var grades = await _gradeDal.GetAllAsync(x => x.IsDeleted); // Silinmis olan siniflari listele
            return grades.OrderBy(x => x.Name).ToList();
        }

        public async Task<List<Grade>> GetListAsync()
        {
            var grades = await _gradeDal.GetAllAsync(x=>!x.IsDeleted); // Silinmemis olan siniflari listele
            return grades.OrderBy(x => x.Name).ToList();
        }

        public async Task TAddAsync(Grade t)
        {
            await _gradeDal.AddAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Grade t)
        {
            await _gradeDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public Task<Grade> TGetByGuidAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Grade> TGetGradeByIdAsync(int id)
        {
            return await _gradeDal.GetGradeByIdAsync(id);
        }

        public async Task<string> TSafeDeleteGradeAsync(int gradeId)
        {
            return await _gradeDal.SafeDeleteGradeAsync(gradeId);
        }

        public async Task<string> TUndoDeleteGradeAsync(int gradeId)
        {
            return await _gradeDal.UndoDeleteGradeAsync(gradeId);
        }

        public async Task TUpdateAsync(Grade t)
        {
            await _gradeDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
