using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Contracts.Infra
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RollBack();
    }
}