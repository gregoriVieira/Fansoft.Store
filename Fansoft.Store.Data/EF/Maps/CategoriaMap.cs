using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fansoft.Store.Data.EF.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable(nameof(Categoria));

            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id).ValueGeneratedOnAdd();
            builder.Property(c=>c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();


        }
    }
}