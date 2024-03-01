using EntityLayer.DTOs.Reports;
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
        Task<List<T>> GetDeletedListAsync();
        Task<T> TGetByGuidAsync(Guid id);
       
    }
}
