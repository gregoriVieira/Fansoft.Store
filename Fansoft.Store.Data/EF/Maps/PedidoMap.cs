using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fansoft.Store.Data.EF.Maps
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable(nameof(Pedido));

            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id).ValueGeneratedOnAdd();

            builder.Property(c=>c.DadosPagto)
                .HasColumnType("varchar(50)")
                .IsRequired();
            
            builder.Property(c=>c.Status)
                .HasColumnType("tinyint");

            builder.HasOne(p=>p.Cliente).WithMany(c=>c.Pedidos).HasForeignKey(fk=>fk.ClienteId);

        }
    }
}