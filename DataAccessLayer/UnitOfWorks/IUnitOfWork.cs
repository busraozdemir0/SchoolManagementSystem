using DataAccessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task<int> SaveAsync();
        int Save();
    }
}
