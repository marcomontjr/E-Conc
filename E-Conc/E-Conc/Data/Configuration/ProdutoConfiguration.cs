using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .Property(p => p.Arquivo)
                .IsRequired();

            builder
                .Property(p => p.Nome)
                .IsRequired();

            builder
                .HasOne(p => p.Orientador)
                .WithMany(o => o.Produtos);
        }
    }
}