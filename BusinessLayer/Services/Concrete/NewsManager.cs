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
    public class NewsManager : INewsService
    {
        private readonly INewsDal _newsDal;
        private readonly IUnitOfWork _unitOfWork;

        public NewsManager(INewsDal newsDal, IUnitOfWork unitOfWork)
        {
            _newsDal = newsDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<News>> GetListAsync()
        {
            return await _newsDal.GetAllAsync();
        }

        public async Task TAddAsync(News t)
        {
            await _newsDal.AddAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(News t)
        {
            await _newsDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<News> TGetByGuidAsync(Guid id)
        {
            return await _newsDal.GetByGuidAsync(id);
        }

        public async Task TUpdateAsync(News t)
        {
            await _newsDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
