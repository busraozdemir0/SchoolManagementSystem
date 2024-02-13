using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Abstract
{
    public interface IRepository<T> where T: class, new()
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        // includeProperties => birbiriyle iliskili olan tablolarda birbirinin alanlarina erisebilmek amaciyla tablolari birbirine include etmek icin kullanilmaktadir.
        // bu sayede veriler birlestirilmis(join) olarak cekilir
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        // filter => bir filtreleme ibaresidir (WHERE kosulu ile yazilan sorgularin ifadesidir)
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter); // Belirtilen kosulu saglayan en az bir kayit varsa true, aksi halde false doner.
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null); // Tablo icerisinde (belirtilen filtreye gore?) kac adet veri oldugunu dondurecek metod
    }
}
