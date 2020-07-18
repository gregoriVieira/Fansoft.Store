using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IPedidoRepository: IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> GetPedidoWithClientesAndItensAsync();
        Task<Pedido> GetPedidoByIdWithClientesAndItensAsync(Guid id);

    }
}
