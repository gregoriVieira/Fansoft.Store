using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Infra;

namespace Fansoft.Store.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDataContext _ctx;
        public UnitOfWork(StoreDataContext ctx) => _ctx = ctx;

        public async Task CommitAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public Task RollBack()
        {
            return null;
        }
    }
}