using System.Collections.Generic;
using System.Linq;
using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Conc.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }

        public new Produto GetById(int? produtoId)
        {
            var produto = (from p in _context.Produtos
                            .Include(u => u.Requisitos)
                            .Include(c => c.Curso)
                            where p.Id.Equals(produtoId)
                            select p).Single();           

            if (produto != null)
                return produto;

            throw new System.Exception("Produto não Encontrado");
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