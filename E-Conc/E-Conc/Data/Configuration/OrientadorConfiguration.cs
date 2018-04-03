using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    internal class OrientadorConfiguration : UsuarioConfiguration<Orientador>
    {
        public override void Configure(EntityTypeBuilder<Orientador> builder)
        {
            base.Configure(builder);
        }
    }
}