using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(StoreDataContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Produto>> GetAllWithCategoriaAsync()
        {
            return await _ctx.Produtos
                                .Include(p=>p.Categoria)
                            .ToListAsync();
        }

        public async Task<Produto> GetByIdWithCategoriaAsync(int id)
        {
            return await _ctx.Produtos
                                .Include(p=>p.Categoria)
                                .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetByNameAsync(string contains)
        {
            return await _ctx.Produtos.Where(p => p.Nome.Contains(contains)).ToListAsync();
        }
    }
}