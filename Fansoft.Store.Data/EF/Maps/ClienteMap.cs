using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fansoft.Store.Data.EF.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id).ValueGeneratedOnAdd();
            builder.Property(c=>c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();


        }
    }
}