using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNewsLetterRepository : Repository<NewsLetter>, INewsLetterDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfNewsLetterRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NewsLetter> GetByIdAsync(int id)
        {
           return await _unitOfWork.GetRepository<NewsLetter>().GetAsync(x=>x.Id == id);

        }

        public async Task<string> SafeDeleteNewsLetterAsync(int newsLetterId)
        {
            var newsLetter = await _unitOfWork.GetRepository<NewsLetter>().GetAsync(x => x.Id == newsLetterId);

            newsLetter.IsDeleted = true;
            newsLetter.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<NewsLetter>().UpdateAsync(newsLetter);
            await _unitOfWork.SaveAsync();

            return newsLetter.EMail;
        }

        public async Task<string> UndoDeleteNewsLetterAsync(int newsLetterId)
        {
            var newsLetter = await _unitOfWork.GetRepository<NewsLetter>().GetAsync(x => x.Id == newsLetterId);

            newsLetter.IsDeleted = false;
            newsLetter.DeletedDate = null;

            await _unitOfWork.GetRepository<NewsLetter>().UpdateAsync(newsLetter);
            await _unitOfWork.SaveAsync();

            return newsLetter.EMail;
        }
    }
}
