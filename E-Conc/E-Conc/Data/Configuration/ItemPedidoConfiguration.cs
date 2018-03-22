using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    internal class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder
               .HasOne(ip => ip.Curso)
               .WithOne()
               .IsRequired();

            builder
                .HasOne(ip => ip.Orientador)
                .WithOne()
                .IsRequired();

            builder
                .HasOne(ip => ip.Produto)
                .WithOne()
                .IsRequired();
        }
    }
}