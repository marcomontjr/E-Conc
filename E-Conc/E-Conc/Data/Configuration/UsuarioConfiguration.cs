using E_Conc.Enum;
using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data
{
    internal class UsuarioConfiguration<T> : IEntityTypeConfiguration<T> where T : Usuario
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .Property(u => u.Login)
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property(u => u.Senha)
                .IsRequired();

            builder
                .Property(u => u.Nome)
                .HasMaxLength(45)
                .IsRequired();
            
            builder
                .Property(u => u.Email)
                .HasMaxLength(45)
                .IsRequired();
            
            builder
                .Property(u => u.Instituicao)
                .IsRequired();

            builder
               .Property(u => u.InstituicaoSigla);

            builder
                .Property(u => u.Telefone)
                .HasMaxLength(35);            
        }
    }
}