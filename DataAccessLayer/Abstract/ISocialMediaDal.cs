using DataAccessLayer.Repository.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISocialMediaDal : IRepository<SocialMedia>
    {
        Task<SocialMedia> GetByIdAsync(int id); // id(int) bilgisine gore SocialMedia getirecek
    }
}
