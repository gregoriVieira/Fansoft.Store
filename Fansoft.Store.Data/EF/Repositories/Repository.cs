using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected StoreDataContext _ctx;
        public Repository(StoreDataContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            // _ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            _ctx.Update(entity);
            // _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            // _ctx.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(object id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        
    }
}