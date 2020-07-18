using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
         //CRUD => Create, Read, Update and Delete
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);

         Task<IEnumerable<T>> GetAsync();
         Task<T> GetAsync(object id);

    }
}