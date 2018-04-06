using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRespository
    {
        public ItemPedidoRepository(Contexto context) : base(context) { }

        public void AddItemPedido(int produtoId)
        {
            var query = (from produto in _context.Produtos
                          .Include(o => o.Orientador)
                          .Include(c => c.Curso)
                          where produto.Id == produtoId
                          select produto).Single();

            if (query != null)
            {
                if (!_context.ItensPedido
                    .Where(i => i.Produto.Id == produtoId)
                    .Any())
                {
                    _context.ItensPedido.Add(
                        new ItemPedido(query));

                    _context.SaveChanges();
                }
            }
        }

        public List<ItemPedido> GetItensPedidos()
        {
            return _context.ItensPedido.ToList();
        }
    }
}