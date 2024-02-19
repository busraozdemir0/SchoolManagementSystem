using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
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
        private readonly AppDbContext _appDbContext;
        public EfNewsLetterRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<NewsLetter> GetByIdAsync(int id)
        {
           return await _appDbContext.NewsLetters.FindAsync(id);

        }
    }
}
