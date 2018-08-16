using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class ProdutoLogRepository : Repository<ProdutoLog>, IProdutoLogRepository
    {
        public ProdutoLogRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }

        public new void Create(ProdutoLog produtoLog)
        {
            _context.Add(produtoLog);
            _context.SaveChanges();
            _context.Dispose();
        }

        public List<ProdutoLog> GetByIdProduto(int produtoId)
        {
            return _context.ProdutoLog
                        .Where(pl => pl.Produto.Id == produtoId)
                        .OrderBy(pl => pl.DataLog)
                        .ToList();
        }
    }
}