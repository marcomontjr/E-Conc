using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRespository
    {
        public ItemPedidoRepository(Contexto context) : base(context) { }

        public ItemPedido AddItemPedido(int produtoId)
        {
           
            var query = (from produto in _context.Produtos
                        .Include(o => o.Orientador)
                        .Include(c => c.Curso)
                         where produto.Id.Equals(produtoId)
                         select produto).Single();

            //TODO: Implementar a Busca do Aluno para a realização da compra.

            if (query != null)
            {
                if (!_context.ItensPedido
                    .Where(i => i.Produto.Id.Equals(produtoId))
                    .Any())
                {

                    var itemPedido = new ItemPedido(query);
                    itemPedido.Id = Guid.NewGuid();
                    _context.ItensPedido.Add(itemPedido);

                    _context.SaveChanges();

                    return itemPedido;
                }
                else
                    throw new System.ArgumentNullException("Já Existe um Pedido para este Item");
            }
            else
                throw new System.ArgumentNullException("Produto Não Encontrado");
        } 

        public List<ItemPedido> GetItensPedidos()
        {
            return _context.ItensPedido.ToList();
        }
    }
}