using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    public class RequisitoConfiguration : IEntityTypeConfiguration<Requisito>
    {
        public void Configure(EntityTypeBuilder<Requisito> builder)
        {
            builder
                .Property(r => r.Nome)
                .IsRequired();

            builder
                .HasOne(p => p.Produto)
                .WithMany(p => p.Requisitos);            
        }
    }
}