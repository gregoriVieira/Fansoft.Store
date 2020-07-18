using System.Threading.Tasks;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
         Task<Usuario> GetByEmailAsync(string email);
    }
}