using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Abstract;
using DataAccessLayer.Repository.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutRepository : Repository<About>, IAboutDal
    {
        private readonly AppDbContext _appDbContext;
        public EfAboutRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _appDbContext.Abouts.FindAsync(id);
        }
    }
}
