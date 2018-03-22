using E_Conc.Data.Configuration;
using E_Conc.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Conc.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }        

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new OrientadorConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
        }
    }
}