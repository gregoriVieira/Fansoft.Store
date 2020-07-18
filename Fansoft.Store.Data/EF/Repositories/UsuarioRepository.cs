using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(StoreDataContext ctx) : base(ctx)
        {
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _ctx.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}