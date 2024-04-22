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
    public class EfMessageRepository : Repository<Message>, IMessageDal
    {
        public EfMessageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
