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
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetterDal;
        private readonly IUnitOfWork _unitOfWork;

        public NewsLetterManager(INewsLetterDal newsLetterDal, IUnitOfWork unitOfWork)
        {
            _newsLetterDal = newsLetterDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<NewsLetter>> GetListAsync()
        {
            return await _newsLetterDal.GetAllAsync();
        }

        public async Task TAddAsync(NewsLetter t)
        {
            await _newsLetterDal.AddAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(NewsLetter t)
        {
            await _newsLetterDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public Task<NewsLetter> TGetByGuidAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<NewsLetter> TGetByIdAsync(int id)
        {
            return await _newsLetterDal.GetByIdAsync(id);
        }

        public Task TUpdateAsync(NewsLetter t)
        {
            throw new NotImplementedException();
        }
    }
}
