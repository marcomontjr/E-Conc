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
                .IsRequired();

            builder
                .Property(u => u.Senha)
                .IsRequired();

            builder
                .Property(u => u.Nome)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .IsRequired();

            builder
                .Property(u => u.Instituicao)
                .IsRequired();
        }
    }
}