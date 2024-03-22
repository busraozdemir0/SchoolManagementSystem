using DataAccessLayer.Context;
using DataAccessLayer.Repository.Abstract;
using DataAccessLayer.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table { get => _context.Set<T>(); }
        
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await Table.AnyAsync(filter);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            if(filter is not null)
                return await Table.CountAsync(filter);

            return await Table.CountAsync();
        }

        public async Task DeleteAsync(T entity) 
        {
            await Task.Run(() => Table.Remove(entity));// Delete islemini asenkron yapida calistirabilmek icin
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            if (filter != null)
                query = query.Where(filter);

            if(includeProperties.Any())
            {
                foreach (var item in includeProperties)
                    query = query.Include(item);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query=query.Where(filter);

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                    query = query.Include(item);
            }

            return await query.SingleAsync();
                
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

		public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=> Table.Update(entity)); // Update islemini asenkron yapida calistirabilmek icin
            return entity;
        }
    }
}
