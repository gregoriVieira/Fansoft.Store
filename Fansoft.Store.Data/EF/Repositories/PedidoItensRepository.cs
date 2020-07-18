using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class PedidoItensRepository : Repository<PedidoItens>, IPedidoItensRepository
    {
        public PedidoItensRepository(StoreDataContext ctx) : base(ctx)
        {
        }
    }
}