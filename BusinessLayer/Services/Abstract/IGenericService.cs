using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IGenericService<T>
    {
        Task TAddAsync(T t);
        Task TDeleteAsync(T t);
        Task TUpdateAsync(T t);
        Task<List<T>> GetListAsync();
        //Task<T> TGetByIdAsync(int id);
        Task<T> TGetByGuidAsync(Guid id);
    }
}
