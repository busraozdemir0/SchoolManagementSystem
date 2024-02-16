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
    public class EfNewsRepository:Repository<News>, INewsDal
    {
        public EfNewsRepository(AppDbContext context) : base(context) // base(context) ile turetilmis sinifin yapici metoduna veritabani baglamini iletiyor.
        {
            
        }
    }
}
