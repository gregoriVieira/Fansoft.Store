using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllWithPedidosAsync();
        Task<Cliente> GetByIdWithPedidosAsync(int id);
    }
}