using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fansoft.Store.Data.EF.Maps
{
    public class PedidoItensMap : IEntityTypeConfiguration<PedidoItens>
    {
        public void Configure(EntityTypeBuilder<PedidoItens> builder)
        {
            builder.ToTable(nameof(PedidoItens));

            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id).ValueGeneratedOnAdd();
           
            
            builder.Property(c=>c.PrecoUnitario)
                .HasColumnType("money");

            builder.Property(c=>c.Quantidade)
                .HasColumnType("real");

            builder.HasOne(p=>p.Pedido).WithMany(c=>c.PedidoItens).HasForeignKey(fk=>fk.PedidoId);
            builder.HasOne(p=>p.Produto).WithMany(c=>c.PedidoItens).HasForeignKey(fk=>fk.ProdutoId);


        }
    }
}