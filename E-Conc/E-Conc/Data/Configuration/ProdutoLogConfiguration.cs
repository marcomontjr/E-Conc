using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    public class ProdutoLogConfiguration : IEntityTypeConfiguration<ProdutoLog>
    {
        public void Configure(EntityTypeBuilder<ProdutoLog> builder)
        {
            builder
                .HasOne(p => p.Produto)
                .WithMany();
        }
    }
}