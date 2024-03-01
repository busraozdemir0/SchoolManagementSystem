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
    public class EfAddressRepository : Repository<Address>, IAddressDal
    {
        public EfAddressRepository(AppDbContext context) : base(context)
        {
         
        }
    }
}
