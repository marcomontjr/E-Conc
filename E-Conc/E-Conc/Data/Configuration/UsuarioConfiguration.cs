using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public virtual void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(u => u.PasswordHash)
                .IsRequired();

            builder
                .Property(u => u.UserName)
                .IsRequired();

            builder
                .Property(u => u.NomeCompleto)
                .HasMaxLength(50);            

            builder
                .Property(u => u.Email)
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property(u => u.Instituicao);

            builder
               .Property(u => u.InstituicaoSigla);

            builder
                .Property(u => u.Ra)
                .HasMaxLength(25);
        }
    }
}