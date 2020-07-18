using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetAllWithCategoriaAsync();
        Task<Produto> GetByIdWithCategoriaAsync(int id);

        Task<IEnumerable<Produto>> GetByNameAsync(string contains);
    }
}