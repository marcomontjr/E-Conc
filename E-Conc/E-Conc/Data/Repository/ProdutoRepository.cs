using System.Collections.Generic;
using System.Linq;
using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;

namespace E_Conc.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Contexto context) : base(context) { }

        public List<Produto> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        public List<Produto> GetProdutosPorCategoria(Categoria categoria)
        {
            return _context.Produtos
                           .Where(c => c.Categoria == categoria)
                           .ToList();
        }
    }
}