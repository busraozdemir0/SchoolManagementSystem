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
    public class EfSocialMediaRepository : Repository<SocialMedia>, ISocialMediaDal
    {
        private readonly AppDbContext _appDbContext;
        public EfSocialMediaRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<SocialMedia> GetByIdAsync(int id)
        {
            return await _appDbContext.SocialMedias.FindAsync(id);
        }
    }
}
