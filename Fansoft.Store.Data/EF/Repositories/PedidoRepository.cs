
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(StoreDataContext ctx) : base(ctx)
        {
        }

        public async Task<Pedido> GetPedidoByIdWithClientesAndItensAsync(Guid id)
        {
            return
                await _ctx.Pedidos
                            .Include(p => p.Cliente)
                            .Include(p => p.PedidoItens).ThenInclude(i=>i.Produto)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedido>> GetPedidoWithClientesAndItensAsync()
        {
            return await _ctx.Pedidos.Include(p => p.Cliente).Include(p => p.PedidoItens).ThenInclude(i=>i.Produto).ToListAsync();
        }
    }
}