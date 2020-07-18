using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(StoreDataContext ctx) : base(ctx)
        {
        }
    }
}