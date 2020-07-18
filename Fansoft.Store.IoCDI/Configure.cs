using Fansoft.Store.Data.EF;
using Fansoft.Store.Data.EF.Repositories;
using Fansoft.Store.Domain.Contracts.Infra;
using Fansoft.Store.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Fansoft.Store.IoCDI
{
    public static class Configure
    {

        public static void AddIoC(this IServiceCollection services)
        {
            //services.AddSingleton(); --> O objeto é único
            //services.AddScoped(); --> é por requisição 
            //services.AddTransient(); --> sempre cria um novo objeto

            services.AddScoped<StoreDataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IPedidoItensRepository, PedidoItensRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

    }
}