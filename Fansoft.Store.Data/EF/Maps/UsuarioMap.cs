using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fansoft.Store.Data.EF.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id).ValueGeneratedOnAdd();

            builder.Property(c=>c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c=>c.Email)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(c=>c.Senha)
                .HasColumnType("char(88)")
                .IsRequired();

        }
    }
}