using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(StoreDataContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Cliente>> GetAllWithPedidosAsync()
        {
            return await _ctx.Clientes.Include(p=>p.Pedidos).ToListAsync();
        }

        public async Task<Cliente> GetByIdWithPedidosAsync(int id)
        {
             return await _ctx.Clientes.Include(p=>p.Pedidos).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}