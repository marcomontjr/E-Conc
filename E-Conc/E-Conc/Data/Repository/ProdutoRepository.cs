using System.Collections.Generic;
using System.Linq;
using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;

namespace E_Conc.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }

        public Produto GetProdutoById(int? produtoId)
        {            
            var produto =  _context.Produtos
                            .Where(p => p.Id == produtoId)
                            .Single();

            if (produto != null)
                return produto;

            throw new System.Exception("Produto não Encontrado");            
        }

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

        public new IEnumerable<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }
    }
}