using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fansoft.Store.Data.EF.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Tabela
            builder.ToTable(nameof(Produto));

            // PK
            builder.HasKey(p => p.Id); // new { id, nome} (Pk Composta)

            // Colunas
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(100)");
             builder.Property(c => c.PrecoUnitario).HasColumnType("money");
            builder.Property(c=>c.QtdeEmEstoque).HasColumnType("real");

            // Relacionamentos
            builder.HasOne(p=>p.Categoria).WithMany(c=>c.Produtos).HasForeignKey(fk=>fk.CategoriaId);



        }
    }
}