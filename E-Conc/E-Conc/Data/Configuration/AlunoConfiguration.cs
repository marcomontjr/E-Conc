﻿using E_Conc.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Conc.Data.Configuration
{
    internal class AlunoConfiguration : UsuarioConfiguration<Aluno>
    {
        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            base.Configure(builder);

            builder
                .Property(a => a.Ra)
                .IsRequired();
        }
    }
}