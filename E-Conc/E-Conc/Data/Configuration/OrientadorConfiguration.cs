using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    internal class OrientadorConfiguration : IEntityTypeConfiguration<Orientador>
    {
        public void Configure(EntityTypeBuilder<Orientador> builder)
        {
            builder
                .Property(o => o.Nome)
                .IsRequired();
        }
    }
}