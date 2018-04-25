﻿using E_Conc.Data.Configuration;
using E_Conc.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Conc.Data
{
    public class Contexto : DbContext
    {
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Orientador> Orientadores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new OrientadorConfiguration());
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
        }
    }
}