using System;
using System.Collections.Generic;
using System.Linq;
using E_Conc.Data.Repository.Interfaces;
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
    }
}
