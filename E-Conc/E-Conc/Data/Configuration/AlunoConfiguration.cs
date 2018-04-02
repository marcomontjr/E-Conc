using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    internal class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder
                .HasKey(a => a.Ra);

            builder
             .Property(a => a.Nome)
             .IsRequired();

            builder
                .Property(a => a.Instituicao)
                .IsRequired();         

            builder
                .Property(a => a.Email)
                .IsRequired();
        }
    }
}